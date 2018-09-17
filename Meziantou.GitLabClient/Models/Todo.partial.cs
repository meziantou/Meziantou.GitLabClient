using System;

namespace Meziantou.GitLab
{
    public partial class Todo
    {
        public GitLabObject Target
        {
            get
            {
                Type type;
                switch (TargetType)
                {
                    case TodoType.Issue:
                        type = typeof(Issue);
                        break;
                    case TodoType.MergeRequest:
                        type = typeof(MergeRequest);
                        break;
                    default:
                        type = typeof(GitLabObject);
                        break;
                }

                return (GitLabObject)GetValueOrDefault("target", type, default(GitLabObject));
            }
        }
    }
}
