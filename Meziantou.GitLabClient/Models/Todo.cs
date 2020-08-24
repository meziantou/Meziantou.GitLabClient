using Meziantou.GitLab.Core;

namespace Meziantou.GitLab
{
    public partial class Todo
    {
        private const string TargetName = "target";

        private GitLabObject? _target;

        [MappedProperty(TargetName)]
        public GitLabObject Target
        {
            get
            {
                if (_target == null)
                {
                    _target = TargetType switch
                    {
                        TodoTargetType.Issue => GetRequiredNonNullValue<Issue>(TargetName),
                        TodoTargetType.MergeRequest => GetRequiredNonNullValue<MergeRequest>(TargetName),
                        _ => GetRequiredNonNullValue<GitLabObject>(TargetName),
                    };
                }

                return _target;
            }
        }
    }
}
