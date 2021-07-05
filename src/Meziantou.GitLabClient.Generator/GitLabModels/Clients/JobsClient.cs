namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal sealed class JobsClient : GitLabClientBuilder
    {
        protected override void Create(MethodGroup methodGroup)
        {
            methodGroup.AddMethod("GetJob", MethodType.Get, "/projects/:id/jobs/:job_id", "https://docs.gitlab.com/ee/api/jobs.html#get-a-single-job")
                .WithReturnType(Models.Job)
                .AddRequiredParameter("id", Models.ProjectIdOrPathRef)
                .AddRequiredParameter("job_id", Models.JobIdRef)
            ;

            methodGroup.AddMethod("GetJobs", MethodType.GetPaged, "/projects/:id/jobs", "https://docs.gitlab.com/ee/api/jobs.html#list-project-jobs")
                .WithReturnType(Models.Job)
                .AddRequiredParameter("id", Models.ProjectIdOrPathRef)
            ;

            methodGroup.AddMethod("GetPipelineJobs", MethodType.GetPaged, "/projects/:id/pipelines/:pipeline_id/jobs", "https://docs.gitlab.com/ee/api/jobs.html#list-pipeline-jobs")
                .WithReturnType(Models.Job)
                .AddRequiredParameter("id", Models.ProjectIdOrPathRef)
                .AddRequiredParameter("pipeline_id", Models.PipelineIdRef)
                .AddOptionalParameter("include_retried", ModelRef.Boolean)
            ;

            methodGroup.AddMethod("RetryJob", MethodType.Post, "/projects/:id/jobs/:job_id/retry", "https://docs.gitlab.com/ee/api/jobs.html#retry-a-job")
                .WithReturnType(Models.Job)
                .AddRequiredParameter("id", Models.ProjectIdOrPathRef)
                .AddRequiredParameter("job_id", Models.JobIdRef)
            ;
        }
    }
}
