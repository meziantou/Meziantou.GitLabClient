﻿namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal sealed class PipelinesClient : GitLabClientBuilder
    {
        protected override void Create(MethodGroup methodGroup)
        {
            methodGroup.AddMethod("CancelPipeline", MethodType.Post, "/projects/:id/pipelines/:pipeline_id/cancel", "https://docs.gitlab.com/ee/api/pipelines.html#cancel-a-pipelines-jobs")
                .WithReturnType(Models.Pipeline)
                .AddRequiredParameter("id", Models.ProjectIdRef)
                .AddRequiredParameter("pipeline_id", Models.PipelineIdRef)
            ;

            methodGroup.AddMethod("CreatePipeline", MethodType.Post, "/projects/:id/pipeline", "https://docs.gitlab.com/ee/api/pipelines.html#create-a-new-pipeline")
                .WithReturnType(Models.Pipeline)
                .AddRequiredParameter("id", Models.ProjectIdRef)
                .AddRequiredParameter("ref", ModelRef.String)
            ;

            methodGroup.AddMethod("DeletePipeline", MethodType.Delete, "/projects/:id/pipelines/:pipeline_id", "https://docs.gitlab.com/ee/api/pipelines.html#delete-a-pipeline")
                .WithReturnType(Models.Pipeline)
                .AddRequiredParameter("id", Models.ProjectIdRef)
                .AddRequiredParameter("pipeline_id", Models.PipelineIdRef)
            ;

            methodGroup.AddMethod("GetPipeline", MethodType.Get, "/projects/:id/pipelines/:pipeline_id", "https://docs.gitlab.com/ee/api/pipelines.html#get-a-single-pipeline")
                .WithReturnType(Models.Pipeline)
                .AddRequiredParameter("id", Models.ProjectIdRef)
                .AddRequiredParameter("pipeline_id", Models.PipelineIdRef)
            ;

            methodGroup.AddMethod("GetPipelines", MethodType.GetPaged, "/projects/:id/pipelines", "https://docs.gitlab.com/ee/api/pipelines.html#list-project-pipelines")
                .WithReturnType(Models.PipelineBasic)
                .AddRequiredParameter("id", Models.ProjectIdRef)
            ;

            methodGroup.AddMethod("RetryPipeline", MethodType.Post, "/projects/:id/pipelines/:pipeline_id/retry", "https://docs.gitlab.com/ee/api/pipelines.html#retry-jobs-in-a-pipeline")
                .WithReturnType(Models.Pipeline)
                .AddRequiredParameter("id", Models.ProjectIdRef)
                .AddRequiredParameter("pipeline_id", Models.PipelineIdRef)
            ;
        }
    }
}
