#pragma warning disable MA0048 // File name must match type name
#pragma warning disable CA1033 // Interface methods should be callable by child types
#pragma warning disable CA1812 // Interface methods should be callable by child types
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;
using Meziantou.GitLab.Core;
using Meziantou.GitLab.Internals;
using Meziantou.GitLab.Serialization;

namespace Meziantou.GitLab
{
    public partial interface IGitLabClient
    {
        IGitLabGraphQLClient GraphQL
        {
            get;
        }
    }

    public partial interface IGitLabGraphQLClient
    {
        /// <summary>
        ///   <para>URL: <c>GET /api/graphql</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/graphql/" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        Task<GraphQLResponse<T>> ExecuteAsync<T>(GraphQLRequest request, RequestOptions? requestOptions = default, CancellationToken cancellationToken = default);
    }

    public partial class GitLabClient : IGitLabGraphQLClient
    {
        public IGitLabGraphQLClient GraphQL => this;

        Task<GraphQLResponse<T>> IGitLabGraphQLClient.ExecuteAsync<T>(GraphQLRequest request, RequestOptions? requestOptions, CancellationToken cancellationToken)
        {
            return GraphQL_ExecuteAsync<T>(request, requestOptions, cancellationToken);
        }

        /// <summary>
        ///   <para>URL: <c>GET /version</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/version.html#version-api" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        private async Task<GraphQLResponse<T>> GraphQL_ExecuteAsync<T>(GraphQLRequest request, RequestOptions? requestOptions = default, CancellationToken cancellationToken = default)
        {
            using var requestMessage = new HttpRequestMessage();
            requestMessage.Method = HttpMethod.Post;
            requestMessage.RequestUri = new Uri("/api/graphql", UriKind.RelativeOrAbsolute);
            requestMessage.Content = new JsonContent(request, JsonSerialization.Options);

            using var response = await SendAsync(requestMessage, requestOptions, cancellationToken).ConfigureAwait(false);
            await response.EnsureStatusCodeAsync(cancellationToken).ConfigureAwait(false);
            var result = await response.ToObjectAsync<GraphQLResponse<T>>(cancellationToken).ConfigureAwait(false);
            if (result == null)
                throw new GitLabException(response.RequestMethod, response.RequestUri, response.StatusCode, $"The response cannot be converted to 'GraphQLResponse<{typeof(T).FullName}>' because the body is null or empty");

            return result;
        }
    }

    [JsonConverter(typeof(GitLabObjectJsonConverterFactory))]
    public sealed class GraphQLResponse<T> : GitLabObject
    {
        internal GraphQLResponse(JsonElement jsonObject)
            : base(jsonObject)
        {
        }

        public T? Data => GetValueOrDefault<T>("data");
        public IReadOnlyCollection<GraphQLError>? Errors => GetValueOrDefault<IReadOnlyCollection<GraphQLError>>("errors");

#pragma warning disable CS8775 // Member 'Errors' must have a non-null value when exiting with 'true'.
        [MemberNotNullWhen(returnValue: true, nameof(Errors))]
        public bool HasErrors
        {
            get
            {
                var errors = Errors;
                return errors != null && errors.Count > 0;
            }
        }
#pragma warning restore CS8775
    }

    [JsonConverter(typeof(GitLabObjectJsonConverterFactory))]
    public sealed class GraphQLError : GitLabObject
    {
        internal GraphQLError(JsonElement jsonObject)
            : base(jsonObject)
        {
        }

        public string Message => GetRequiredNonNullValue<string>("message");
        public IReadOnlyList<GraphQLErrorLocation>? Locations => GetValueOrDefault<IReadOnlyList<GraphQLErrorLocation>>("locations");
        public IReadOnlyList<string>? Paths => GetValueOrDefault<IReadOnlyList<string>>("paths");
    }

    [JsonConverter(typeof(GitLabObjectJsonConverterFactory))]
    public sealed class GraphQLErrorLocation : GitLabObject
    {
        internal GraphQLErrorLocation(JsonElement jsonObject)
            : base(jsonObject)
        {
        }

        public int Line => GetRequiredNonNullValue<int>("line");
        public int Column => GetRequiredNonNullValue<int>("column");
    }

    public sealed class GraphQLRequest
    {
        public GraphQLRequest(string query)
        {
            Query = query;
        }

        [JsonPropertyName("query")]
        public string Query { get; set; }

        [JsonPropertyName("PperationName")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? OperationName { get; set; }

        [JsonPropertyName("variables")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        [SuppressMessage("Usage", "CA2227:Collection properties should be read only", Justification = "Null is a valid value here")]
        public IDictionary<string, object?>? Variables { get; set; }
    }
}
