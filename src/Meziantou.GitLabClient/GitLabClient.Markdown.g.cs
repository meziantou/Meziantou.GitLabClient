﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated
// </auto-generated>
// ------------------------------------------------------------------------------
#nullable enable
namespace Meziantou.GitLab
{
    public partial interface IGitLabClient
    {
        Meziantou.GitLab.IGitLabMarkdownClient Markdown
        {
            get;
        }
    }

    public partial interface IGitLabMarkdownClient
    {
        /// <summary>
        ///   <para>URL: <c>POST /markdown</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/markdown.html#render-an-arbitrary-markdown-document" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<RenderMarkdownResult> RenderMarkdownAsync(Meziantou.GitLab.RenderMarkdownRequest request, Meziantou.GitLab.RequestOptions? requestOptions = default(Meziantou.GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }

    public partial class GitLabClient : Meziantou.GitLab.IGitLabMarkdownClient
    {
        /// <summary>
        ///   <para>URL: <c>POST /markdown</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/markdown.html#render-an-arbitrary-markdown-document" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<RenderMarkdownResult> Meziantou.GitLab.IGitLabMarkdownClient.RenderMarkdownAsync(Meziantou.GitLab.RenderMarkdownRequest request, Meziantou.GitLab.RequestOptions? requestOptions, System.Threading.CancellationToken cancellationToken)
        {
            return this.Markdown_RenderMarkdownAsync(request, requestOptions, cancellationToken);
        }

        public Meziantou.GitLab.IGitLabMarkdownClient Markdown
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        ///   <para>URL: <c>POST /markdown</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/markdown.html#render-an-arbitrary-markdown-document" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        private async System.Threading.Tasks.Task<RenderMarkdownResult> Markdown_RenderMarkdownAsync(Meziantou.GitLab.RenderMarkdownRequest request, Meziantou.GitLab.RequestOptions? requestOptions = default(Meziantou.GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            string url = Meziantou.GitLab.GitLabClient.Markdown_RenderMarkdownAsync_BuildUrl();
            using (System.Net.Http.HttpRequestMessage requestMessage = new System.Net.Http.HttpRequestMessage())
            {
                requestMessage.Method = System.Net.Http.HttpMethod.Post;
                requestMessage.RequestUri = new System.Uri(url, System.UriKind.RelativeOrAbsolute);
                Meziantou.GitLab.Internals.UnsafeListDictionary<string, object?> body = new Meziantou.GitLab.Internals.UnsafeListDictionary<string, object?>(3);
                if ((request.Text != null))
                {
                    body.Add("text", request.Text);
                }

                if ((request.Gfm != null))
                {
                    body.Add("gfm", request.Gfm);
                }

                if ((request.Project != null))
                {
                    body.Add("project", request.Project);
                }

                requestMessage.Content = new Meziantou.GitLab.Internals.JsonContent(body, Meziantou.GitLab.Serialization.JsonSerialization.Options);
                HttpResponse? response = null;
                try
                {
                    response = await this.SendAsync(requestMessage, requestOptions, cancellationToken).ConfigureAwait(false);
                    await response.EnsureStatusCodeAsync(cancellationToken).ConfigureAwait(false);
                    RenderMarkdownResult? result = await response.ToObjectAsync<RenderMarkdownResult>(cancellationToken).ConfigureAwait(false);
                    if ((result == null))
                    {
                        throw new Meziantou.GitLab.GitLabException(response.RequestMethod, response.RequestUri, response.StatusCode, "The response cannot be converted to 'RenderMarkdownResult' because the body is null or empty");
                    }

                    return result;
                }
                finally
                {
                    if ((response != null))
                    {
                        response.Dispose();
                    }
                }
            }
        }

        private static string Markdown_RenderMarkdownAsync_BuildUrl()
        {
            string url;
            url = "markdown";
            return url;
        }
    }

    public static partial class GitLabClientExtensions
    {
        /// <summary>
        ///   <para>URL: <c>POST /markdown</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/markdown.html#render-an-arbitrary-markdown-document" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task<RenderMarkdownResult> RenderMarkdownAsync(this Meziantou.GitLab.IGitLabMarkdownClient client, string text, bool? gfm = default(bool?), Meziantou.GitLab.PathWithNamespace? project = default(Meziantou.GitLab.PathWithNamespace?), Meziantou.GitLab.RequestOptions? requestOptions = default(Meziantou.GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.RenderMarkdownRequest request = new Meziantou.GitLab.RenderMarkdownRequest(text);
            request.Gfm = gfm;
            request.Project = project;
            return client.RenderMarkdownAsync(request, requestOptions, cancellationToken);
        }
    }

    public partial class RenderMarkdownRequest
    {
        private bool? _gfm;

        private Meziantou.GitLab.PathWithNamespace? _project;

        private string? _text;

        /// <param name="text">The Markdown text to render</param>
        public RenderMarkdownRequest(string? text)
        {
            this._text = text;
        }

        public RenderMarkdownRequest()
        {
        }

        /// <summary>
        ///   <para>Render text using GitLab Flavored Markdown. Default is false</para>
        /// </summary>
        public bool? Gfm
        {
            get
            {
                return this._gfm;
            }
            set
            {
                this._gfm = value;
            }
        }

        /// <summary>
        ///   <para>Use project as a context when creating references using GitLab Flavored Markdown. Authentication is required if a project is not public.</para>
        /// </summary>
        public Meziantou.GitLab.PathWithNamespace? Project
        {
            get
            {
                return this._project;
            }
            set
            {
                this._project = value;
            }
        }

        /// <summary>
        ///   <para>The Markdown text to render</para>
        /// </summary>
        public string? Text
        {
            get
            {
                return this._text;
            }
            set
            {
                this._text = value;
            }
        }
    }
}
