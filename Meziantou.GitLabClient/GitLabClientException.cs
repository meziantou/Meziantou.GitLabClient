using System;
using System.Runtime.Serialization;

namespace Meziantou.GitLab
{
    public class GitLabClientException : Exception
    {
        public GitLabClientException()
        {
        }

        public GitLabClientException(string message)
            : base(message)
        {
        }

        public GitLabClientException(GitLabError error)
            : base(error.ErrorDescription ?? error.Error.ToString())
        {
            ErrorObject = error;
        }

        public GitLabClientException(GitLabError error, string message)
            : base(message)
        {
            ErrorObject = error;
        }

        public GitLabClientException(GitLabError error, string message, Exception innerException)
            : base(message, innerException)
        {
            ErrorObject = error;
        }

        protected GitLabClientException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public GitLabError ErrorObject { get; }
    }

    public class NotFoundException : GitLabClientException
    {
        public NotFoundException()
        {
        }

        public NotFoundException(GitLabError error)
            : base(error)
        {
        }

        public NotFoundException(string message)
            : base(message)
        {
        }

        public NotFoundException(GitLabError error, string message)
            : base(error, message)
        {
        }

        public NotFoundException(GitLabError error, string message, Exception innerException)
            : base(error, message, innerException)
        {
        }

        protected NotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
