namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal sealed class LicenseClient : GitLabClientBuilder
    {
        protected override void Create(MethodGroup methodGroup)
        {
            methodGroup.AddMethod("GetCurrentLicense", MethodType.Get, "/license", "https://docs.gitlab.com/ee/api/license.html#retrieve-information-about-the-current-license")
                .WithReturnType(Models.License)
                ;

            methodGroup.AddMethod("GetLicenses", MethodType.GetPaged, "/licenses", "https://docs.gitlab.com/ee/api/license.html#retrieve-information-about-all-licenses")
                .WithReturnType(Models.License)
                ;

            methodGroup.AddMethod("AddLicense", MethodType.Post, "/license", "https://docs.gitlab.com/ee/api/license.html#add-a-new-license")
                .WithReturnType(Models.License)
                .AddRequiredParameter("license", ModelRef.String, ParameterLocation.Url)
                ;

            methodGroup.AddMethod("DeleteLicense", MethodType.Delete, "/license/:id", "https://docs.gitlab.com/ee/api/license.html#delete-a-license")
                .AddRequiredParameter("id", ModelRef.NumberId)
                ;
        }
    }
}
