namespace Meziantou.GitLabClient.Generator.GitLabModels.Clients
{
    internal sealed class JobArtifactsClient : GitLabClientBuilder
    {
        protected override void Create(MethodGroup methodGroup)
        {
            methodGroup.AddMethod("DownloadArtifactArchiveByJobId", MethodType.Get, "/projects/:id/jobs/:job_id/artifacts", "https://docs.gitlab.com/ee/api/job_artifacts.html#get-job-artifacts")
                .WithReturnType(ModelRef.Stream)
                .AddRequiredParameter("id", Models.ProjectIdOrPathRef)
                .AddRequiredParameter("job_id", ModelRef.String)
                .AddOptionalParameter("job_token", ModelRef.String)
                ;

            methodGroup.AddMethod("DownloadArtifactArchiveFromTagOrBranch", MethodType.Get, "/projects/:id/jobs/artifacts/:ref_name/download", "https://docs.gitlab.com/ee/api/job_artifacts.html#download-the-artifacts-archive")
                .WithReturnType(ModelRef.Stream)
                .AddRequiredParameter("id", Models.ProjectIdOrPathRef)
                .AddRequiredParameter("ref_name", ModelRef.String)
                .AddRequiredParameter("job", ModelRef.String)
                .AddOptionalParameter("job_token", ModelRef.String)
                ;

            methodGroup.AddMethod("DownloadArtifactFileByJobId", MethodType.Get, "/projects/:id/jobs/:job_id/artifacts/*artifact_path", "https://docs.gitlab.com/ee/api/job_artifacts.html#download-a-single-artifact-file-by-job-id")
                .WithReturnType(ModelRef.Stream)
                .AddRequiredParameter("id", Models.ProjectIdOrPathRef)
                .AddRequiredParameter("job_id", ModelRef.NumberId)
                .AddRequiredParameter("artifact_path", ModelRef.String)
                ;

            methodGroup.AddMethod("DownloadArtifactFileFromTagOrBranch", MethodType.Get, "/projects/:id/jobs/artifacts/:ref_name/raw/*artifact_path", "https://docs.gitlab.com/ee/api/job_artifacts.html#download-a-single-artifact-file-from-specific-tag-or-branch")
                .WithReturnType(ModelRef.Stream)
                .AddRequiredParameter("id", Models.ProjectIdOrPathRef)
                .AddRequiredParameter("ref_name", ModelRef.String)
                .AddRequiredParameter("artifact_path", ModelRef.String)
                .AddRequiredParameter("job", ModelRef.String)
                ;
        }
    }
}
