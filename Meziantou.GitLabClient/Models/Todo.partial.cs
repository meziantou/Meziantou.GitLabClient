using Meziantou.GitLab.Core;

namespace Meziantou.GitLab
{
    public partial class Todo
    {
        private const string TargetName = "target";

        private GitLabObject _target;

        [MappedProperty(TargetName)]
        public GitLabObject Target
        {
            get
            {
                if (_target == null)
                {
                    _target = TargetType switch
                    {
                        TodoType.Issue => GetValueOrDefault<Issue>(TargetName),
                        TodoType.MergeRequest => GetValueOrDefault<MergeRequest>(TargetName),
                        _ => GetValueOrDefault<GitLabObject>(TargetName),
                    };
                }

                return _target;
            }
        }
    }
}
