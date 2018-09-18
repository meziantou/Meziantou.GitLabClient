using System;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Text;

namespace Meziantou.GitLab
{
    public class GitLabException : Exception
    {
        public GitLabException()
        {
        }

        public GitLabException(string message)
            : base(message)
        {
        }

        public GitLabException(HttpMethod httpMethod, Uri requestUri, HttpStatusCode httpStatusCode, GitLabError error)
            : base(GetMessage(error))
        {
            HttpMethod = httpMethod;
            RequestUri = requestUri;
            HttpStatusCode = httpStatusCode;
            ErrorObject = error;
        }

        public GitLabException(HttpMethod httpMethod, Uri requestUri, HttpStatusCode httpStatusCode, string message)
            : base(message)
        {
            HttpMethod = httpMethod;
            RequestUri = requestUri;
            HttpStatusCode = httpStatusCode;
        }

        public GitLabException(GitLabError error, string message)
            : base(message)
        {
            ErrorObject = error;
        }

        public GitLabException(GitLabError error, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorObject = error;
        }

        protected GitLabException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public HttpMethod HttpMethod { get; }
        public Uri RequestUri { get; }
        public HttpStatusCode HttpStatusCode { get; }
        public GitLabError ErrorObject { get; }

        private static string GetMessage(GitLabError error)
        {
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

            return null;
        }
    }
}
