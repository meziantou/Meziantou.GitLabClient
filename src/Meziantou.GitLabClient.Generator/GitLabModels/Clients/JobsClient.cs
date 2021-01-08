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
        }
    }
}
