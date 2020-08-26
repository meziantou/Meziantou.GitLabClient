using System;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Meziantou.GitLab
{
    [SuppressMessage("Design", "CA1032:Implement standard exception constructors", Justification = "Ensure the properties are set")]
    public class GitLabException : Exception
    {
        public GitLabException(HttpMethod? httpMethod, Uri? requestUri, HttpStatusCode httpStatusCode, GitLabError? error)
            : base(GetMessage(error))
        {
            HttpMethod = httpMethod;
            RequestUri = requestUri;
            HttpStatusCode = httpStatusCode;
            ErrorObject = error;
        }

        public GitLabException(HttpMethod? httpMethod, Uri? requestUri, HttpStatusCode httpStatusCode, string message)
            : base(message)
        {
            HttpMethod = httpMethod;
            RequestUri = requestUri;
            HttpStatusCode = httpStatusCode;
        }

        public HttpMethod? HttpMethod { get; }
        public Uri? RequestUri { get; }
        public HttpStatusCode HttpStatusCode { get; }
        public GitLabError? ErrorObject { get; }

        private static string? GetMessage(GitLabError? error)
        {
            if (error == null)
                return null;

            if (error.ErrorDescription != null)
                return error.ErrorDescription;

            if (error.Error != null)
                return error.Error;

            var message = error.Message;
            if (message != null)
                return message;

            var messages = error.Messages;
            if (messages != null)
            {
                var sb = new StringBuilder();
                foreach (var msg in messages)
                {
                    foreach (var value in msg.Value)
                    {
                        sb.Append(msg.Key).Append(' ').AppendLine(value);
                    }
                }

                return sb.ToString();
            }

            return error._jsonObject.ToString();
        }
    }
}
