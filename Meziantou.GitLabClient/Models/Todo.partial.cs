namespace Meziantou.GitLab
{
    public partial class Todo
    {
        private GitLabObject _target;

        [MappedProperty("target")]
        public GitLabObject Target
        {
            get
            {
                if (_target == null)
                {
                    var type = TargetType switch
                    {
                        TodoType.Issue => typeof(Issue),
                        TodoType.MergeRequest => typeof(MergeRequest),
                        _ => typeof(GitLabObject),
                    };

                    _target = (GitLabObject)GetValueOrDefault("target", type, default(GitLabObject));
                }

                return _target;
            }
        }
    }
}
