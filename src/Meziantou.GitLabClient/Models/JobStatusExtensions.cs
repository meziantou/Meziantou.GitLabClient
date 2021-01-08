using System;
using System.Diagnostics.CodeAnalysis;

namespace Meziantou.GitLab.Models
{
    public static class JobStatusExtensions
    {
        /// <remarks><see cref="JobStatus.Manual"/> and <see cref="JobStatus.Skipped"/> are considered as completed</remarks>
        [SuppressMessage("Style", "IDE0066:Convert switch statement to expression", Justification = "Less readable")]
        public static bool IsCompleted(this JobStatus jobStatus)
        {
            switch (jobStatus)
            {
                case JobStatus.Created:
                case JobStatus.Pending:
                case JobStatus.Running:
                    return false;

                case JobStatus.Failed:
                case JobStatus.Success:
                case JobStatus.Canceled:
                case JobStatus.Skipped:
                case JobStatus.Manual:
                    return true;

                default:
                    throw new ArgumentOutOfRangeException(nameof(jobStatus));
            }
        }
    }
}
