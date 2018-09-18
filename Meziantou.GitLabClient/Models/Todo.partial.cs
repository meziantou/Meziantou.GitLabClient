using System;

namespace Meziantou.GitLab
{
    public partial class Todo
    {
        private GitLabObject _target;

        public GitLabObject Target
        {
            get
            {
                if (_target == null)
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

                    _target = (GitLabObject)GetValueOrDefault("target", type, default(GitLabObject));
                }

                return _target;
            }
        }
    }
}
