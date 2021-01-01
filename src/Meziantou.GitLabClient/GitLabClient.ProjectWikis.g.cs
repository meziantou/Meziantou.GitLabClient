﻿// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated
// </auto-generated>
// ------------------------------------------------------------------------------
#nullable enable
namespace Meziantou.GitLab
{
    public partial interface IGitLabClient
    {
        Meziantou.GitLab.IGitLabProjectWikisClient ProjectWikis
        {
            get;
        }
    }

    public partial interface IGitLabProjectWikisClient
    {
        /// <summary>
        ///   <para>URL: <c>POST /projects/:id/wikis</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/wikis.html#create-a-new-wiki-page" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<WikiPage> CreateWikiPageAsync(Meziantou.GitLab.CreateWikiPageProjectWikiRequest request, Meziantou.GitLab.RequestOptions? requestOptions = default(Meziantou.GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        ///   <para>URL: <c>DELETE /projects/:id/wikis/:slug</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/wikis.html#delete-a-wiki-page" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task DeleteWikiPageAsync(Meziantou.GitLab.DeleteWikiPageProjectWikiRequest request, Meziantou.GitLab.RequestOptions? requestOptions = default(Meziantou.GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        ///   <para>URL: <c>GET /projects/:id/wikis/:slug</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/wikis.html#get-a-wiki-page" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<WikiPage?> GetWikiPageAsync(Meziantou.GitLab.GetWikiPageProjectWikiRequest request, Meziantou.GitLab.RequestOptions? requestOptions = default(Meziantou.GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        ///   <para>URL: <c>GET /projects/:id/wikis</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/wikis.html#list-wiki-pages" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<WikiPage>> GetWikiPagesAsync(Meziantou.GitLab.GetWikiPagesProjectWikiRequest request, Meziantou.GitLab.RequestOptions? requestOptions = default(Meziantou.GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        ///   <para>URL: <c>PUT /projects/:id/wikis/:slug</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/wikis.html#edit-an-existing-wiki-page" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<WikiPage> UpdateWikiPageAsync(Meziantou.GitLab.UpdateWikiPageProjectWikiRequest request, Meziantou.GitLab.RequestOptions? requestOptions = default(Meziantou.GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }

    public partial class GitLabClient : Meziantou.GitLab.IGitLabProjectWikisClient
    {
        /// <summary>
        ///   <para>URL: <c>POST /projects/:id/wikis</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/wikis.html#create-a-new-wiki-page" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<WikiPage> Meziantou.GitLab.IGitLabProjectWikisClient.CreateWikiPageAsync(Meziantou.GitLab.CreateWikiPageProjectWikiRequest request, Meziantou.GitLab.RequestOptions? requestOptions, System.Threading.CancellationToken cancellationToken)
        {
            return this.ProjectWikis_CreateWikiPageAsync(request, requestOptions, cancellationToken);
        }

        /// <summary>
        ///   <para>URL: <c>DELETE /projects/:id/wikis/:slug</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/wikis.html#delete-a-wiki-page" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task Meziantou.GitLab.IGitLabProjectWikisClient.DeleteWikiPageAsync(Meziantou.GitLab.DeleteWikiPageProjectWikiRequest request, Meziantou.GitLab.RequestOptions? requestOptions, System.Threading.CancellationToken cancellationToken)
        {
            return this.ProjectWikis_DeleteWikiPageAsync(request, requestOptions, cancellationToken);
        }

        /// <summary>
        ///   <para>URL: <c>GET /projects/:id/wikis/:slug</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/wikis.html#get-a-wiki-page" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<WikiPage?> Meziantou.GitLab.IGitLabProjectWikisClient.GetWikiPageAsync(Meziantou.GitLab.GetWikiPageProjectWikiRequest request, Meziantou.GitLab.RequestOptions? requestOptions, System.Threading.CancellationToken cancellationToken)
        {
            return this.ProjectWikis_GetWikiPageAsync(request, requestOptions, cancellationToken);
        }

        /// <summary>
        ///   <para>URL: <c>GET /projects/:id/wikis</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/wikis.html#list-wiki-pages" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<WikiPage>> Meziantou.GitLab.IGitLabProjectWikisClient.GetWikiPagesAsync(Meziantou.GitLab.GetWikiPagesProjectWikiRequest request, Meziantou.GitLab.RequestOptions? requestOptions, System.Threading.CancellationToken cancellationToken)
        {
            return this.ProjectWikis_GetWikiPagesAsync(request, requestOptions, cancellationToken);
        }

        /// <summary>
        ///   <para>URL: <c>PUT /projects/:id/wikis/:slug</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/wikis.html#edit-an-existing-wiki-page" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<WikiPage> Meziantou.GitLab.IGitLabProjectWikisClient.UpdateWikiPageAsync(Meziantou.GitLab.UpdateWikiPageProjectWikiRequest request, Meziantou.GitLab.RequestOptions? requestOptions, System.Threading.CancellationToken cancellationToken)
        {
            return this.ProjectWikis_UpdateWikiPageAsync(request, requestOptions, cancellationToken);
        }

        public Meziantou.GitLab.IGitLabProjectWikisClient ProjectWikis
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        ///   <para>URL: <c>POST /projects/:id/wikis</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/wikis.html#create-a-new-wiki-page" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Reliability", "CA2000:Dispose objects before losing scope", Justification = "The rule doesn't understand ref struct")]
        private System.Threading.Tasks.Task<WikiPage> ProjectWikis_CreateWikiPageAsync(Meziantou.GitLab.CreateWikiPageProjectWikiRequest request, Meziantou.GitLab.RequestOptions? requestOptions = default(Meziantou.GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            string url;
            using (Meziantou.GitLab.Internals.UrlBuilder urlBuilder = new Meziantou.GitLab.Internals.UrlBuilder())
            {
                urlBuilder.Append("projects/");
                if (request.Id.HasValue)
                {
                    urlBuilder.AppendParameter(request.Id.GetValueOrDefault().ValueAsString);
                }

                urlBuilder.Append("/wikis");
                url = urlBuilder.ToString();
            }

            System.Collections.Generic.Dictionary<string, object> body = new System.Collections.Generic.Dictionary<string, object>();
            if ((request.Title != null))
            {
                body.Add("title", request.Title);
            }

            if ((request.Content != null))
            {
                body.Add("content", request.Content);
            }

            if ((request.Format != null))
            {
                body.Add("format", request.Format);
            }

            return this.PostJsonAsync<WikiPage>(url, body, requestOptions, cancellationToken);
        }

        /// <summary>
        ///   <para>URL: <c>DELETE /projects/:id/wikis/:slug</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/wikis.html#delete-a-wiki-page" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Reliability", "CA2000:Dispose objects before losing scope", Justification = "The rule doesn't understand ref struct")]
        private System.Threading.Tasks.Task ProjectWikis_DeleteWikiPageAsync(Meziantou.GitLab.DeleteWikiPageProjectWikiRequest request, Meziantou.GitLab.RequestOptions? requestOptions = default(Meziantou.GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            string url;
            using (Meziantou.GitLab.Internals.UrlBuilder urlBuilder = new Meziantou.GitLab.Internals.UrlBuilder())
            {
                urlBuilder.Append("projects/");
                if (request.Id.HasValue)
                {
                    urlBuilder.AppendParameter(request.Id.GetValueOrDefault().ValueAsString);
                }

                urlBuilder.Append("/wikis/");
                if ((!object.ReferenceEquals(request.Slug, null)))
                {
                    urlBuilder.AppendParameter(request.Slug);
                }

                url = urlBuilder.ToString();
            }

            return this.DeleteAsync(url, requestOptions, cancellationToken);
        }

        /// <summary>
        ///   <para>URL: <c>GET /projects/:id/wikis/:slug</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/wikis.html#get-a-wiki-page" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Reliability", "CA2000:Dispose objects before losing scope", Justification = "The rule doesn't understand ref struct")]
        private System.Threading.Tasks.Task<WikiPage?> ProjectWikis_GetWikiPageAsync(Meziantou.GitLab.GetWikiPageProjectWikiRequest request, Meziantou.GitLab.RequestOptions? requestOptions = default(Meziantou.GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            string url;
            using (Meziantou.GitLab.Internals.UrlBuilder urlBuilder = new Meziantou.GitLab.Internals.UrlBuilder())
            {
                urlBuilder.Append("projects/");
                if (request.Id.HasValue)
                {
                    urlBuilder.AppendParameter(request.Id.GetValueOrDefault().ValueAsString);
                }

                urlBuilder.Append("/wikis/");
                if ((!object.ReferenceEquals(request.Slug, null)))
                {
                    urlBuilder.AppendParameter(request.Slug);
                }

                url = urlBuilder.ToString();
            }

            return this.GetAsync<WikiPage>(url, requestOptions, cancellationToken);
        }

        /// <summary>
        ///   <para>URL: <c>GET /projects/:id/wikis</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/wikis.html#list-wiki-pages" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Reliability", "CA2000:Dispose objects before losing scope", Justification = "The rule doesn't understand ref struct")]
        private System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<WikiPage>> ProjectWikis_GetWikiPagesAsync(Meziantou.GitLab.GetWikiPagesProjectWikiRequest request, Meziantou.GitLab.RequestOptions? requestOptions = default(Meziantou.GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            string url;
            using (Meziantou.GitLab.Internals.UrlBuilder urlBuilder = new Meziantou.GitLab.Internals.UrlBuilder())
            {
                urlBuilder.Append("projects/");
                if (request.Id.HasValue)
                {
                    urlBuilder.AppendParameter(request.Id.GetValueOrDefault().ValueAsString);
                }

                urlBuilder.Append("/wikis");
                url = urlBuilder.ToString();
            }

            return this.GetCollectionAsync<WikiPage>(url, requestOptions, cancellationToken);
        }

        /// <summary>
        ///   <para>URL: <c>PUT /projects/:id/wikis/:slug</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/wikis.html#edit-an-existing-wiki-page" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Reliability", "CA2000:Dispose objects before losing scope", Justification = "The rule doesn't understand ref struct")]
        private System.Threading.Tasks.Task<WikiPage> ProjectWikis_UpdateWikiPageAsync(Meziantou.GitLab.UpdateWikiPageProjectWikiRequest request, Meziantou.GitLab.RequestOptions? requestOptions = default(Meziantou.GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            string url;
            using (Meziantou.GitLab.Internals.UrlBuilder urlBuilder = new Meziantou.GitLab.Internals.UrlBuilder())
            {
                urlBuilder.Append("projects/");
                if (request.Id.HasValue)
                {
                    urlBuilder.AppendParameter(request.Id.GetValueOrDefault().ValueAsString);
                }

                urlBuilder.Append("/wikis/");
                if ((!object.ReferenceEquals(request.Slug, null)))
                {
                    urlBuilder.AppendParameter(request.Slug);
                }

                url = urlBuilder.ToString();
            }

            System.Collections.Generic.Dictionary<string, object> body = new System.Collections.Generic.Dictionary<string, object>();
            if ((request.Title != null))
            {
                body.Add("title", request.Title);
            }

            if ((request.Content != null))
            {
                body.Add("content", request.Content);
            }

            if ((request.Format != null))
            {
                body.Add("format", request.Format);
            }

            return this.PutJsonAsync<WikiPage>(url, body, requestOptions, cancellationToken);
        }
    }

    public static partial class GitLabClientExtensions
    {
        /// <summary>
        ///   <para>URL: <c>POST /projects/:id/wikis</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/wikis.html#create-a-new-wiki-page" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task<WikiPage> CreateWikiPageAsync(this Meziantou.GitLab.IGitLabProjectWikisClient client, ProjectIdOrPathRef id, string title, string content, WikiPageFormat? format = default(WikiPageFormat?), Meziantou.GitLab.RequestOptions? requestOptions = default(Meziantou.GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.CreateWikiPageProjectWikiRequest request = new Meziantou.GitLab.CreateWikiPageProjectWikiRequest(id, title, content);
            request.Format = format;
            return client.CreateWikiPageAsync(request, requestOptions, cancellationToken);
        }

        /// <summary>
        ///   <para>URL: <c>DELETE /projects/:id/wikis/:slug</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/wikis.html#delete-a-wiki-page" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task DeleteWikiPageAsync(this Meziantou.GitLab.IGitLabProjectWikisClient client, ProjectIdOrPathRef id, string slug, Meziantou.GitLab.RequestOptions? requestOptions = default(Meziantou.GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.DeleteWikiPageProjectWikiRequest request = new Meziantou.GitLab.DeleteWikiPageProjectWikiRequest(id, slug);
            return client.DeleteWikiPageAsync(request, requestOptions, cancellationToken);
        }

        /// <summary>
        ///   <para>URL: <c>GET /projects/:id/wikis/:slug</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/wikis.html#get-a-wiki-page" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task<WikiPage?> GetWikiPageAsync(this Meziantou.GitLab.IGitLabProjectWikisClient client, ProjectIdOrPathRef id, string slug, Meziantou.GitLab.RequestOptions? requestOptions = default(Meziantou.GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.GetWikiPageProjectWikiRequest request = new Meziantou.GitLab.GetWikiPageProjectWikiRequest(id, slug);
            return client.GetWikiPageAsync(request, requestOptions, cancellationToken);
        }

        /// <summary>
        ///   <para>URL: <c>GET /projects/:id/wikis</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/wikis.html#list-wiki-pages" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task<System.Collections.Generic.IReadOnlyList<WikiPage>> GetWikiPagesAsync(this Meziantou.GitLab.IGitLabProjectWikisClient client, ProjectIdOrPathRef id, Meziantou.GitLab.RequestOptions? requestOptions = default(Meziantou.GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.GetWikiPagesProjectWikiRequest request = new Meziantou.GitLab.GetWikiPagesProjectWikiRequest(id);
            return client.GetWikiPagesAsync(request, requestOptions, cancellationToken);
        }

        /// <summary>
        ///   <para>URL: <c>PUT /projects/:id/wikis/:slug</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/wikis.html#edit-an-existing-wiki-page" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task<WikiPage> UpdateWikiPageAsync(this Meziantou.GitLab.IGitLabProjectWikisClient client, ProjectIdOrPathRef id, string slug, string? title = default(string?), string? content = default(string?), WikiPageFormat? format = default(WikiPageFormat?), Meziantou.GitLab.RequestOptions? requestOptions = default(Meziantou.GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.UpdateWikiPageProjectWikiRequest request = new Meziantou.GitLab.UpdateWikiPageProjectWikiRequest(id, slug);
            request.Title = title;
            request.Content = content;
            request.Format = format;
            return client.UpdateWikiPageAsync(request, requestOptions, cancellationToken);
        }
    }

    public partial class GetWikiPagesProjectWikiRequest
    {
        private ProjectIdOrPathRef? _id;

        /// <param name="id">The ID or URL-encoded path of the project</param>
        public GetWikiPagesProjectWikiRequest(ProjectIdOrPathRef? id)
        {
            this._id = id;
        }

        public GetWikiPagesProjectWikiRequest()
        {
        }

        /// <summary>
        ///   <para>The ID or URL-encoded path of the project</para>
        /// </summary>
        public ProjectIdOrPathRef? Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
    }

    public partial class GetWikiPageProjectWikiRequest
    {
        private ProjectIdOrPathRef? _id;

        private string? _slug;

        /// <param name="id">The ID or URL-encoded path of the project</param>
        /// <param name="slug">The slug (a unique string) of the wiki page</param>
        public GetWikiPageProjectWikiRequest(ProjectIdOrPathRef? id, string? slug)
        {
            this._id = id;
            this._slug = slug;
        }

        public GetWikiPageProjectWikiRequest()
        {
        }

        /// <summary>
        ///   <para>The ID or URL-encoded path of the project</para>
        /// </summary>
        public ProjectIdOrPathRef? Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        /// <summary>
        ///   <para>The slug (a unique string) of the wiki page</para>
        /// </summary>
        public string? Slug
        {
            get
            {
                return this._slug;
            }
            set
            {
                this._slug = value;
            }
        }
    }

    public partial class CreateWikiPageProjectWikiRequest
    {
        private string? _content;

        private WikiPageFormat? _format;

        private ProjectIdOrPathRef? _id;

        private string? _title;

        /// <param name="id">The ID or URL-encoded path of the project</param>
        /// <param name="title">The title of the wiki page</param>
        /// <param name="content">The content of the wiki page</param>
        public CreateWikiPageProjectWikiRequest(ProjectIdOrPathRef? id, string? title, string? content)
        {
            this._id = id;
            this._title = title;
            this._content = content;
        }

        public CreateWikiPageProjectWikiRequest()
        {
        }

        /// <summary>
        ///   <para>The content of the wiki page</para>
        /// </summary>
        public string? Content
        {
            get
            {
                return this._content;
            }
            set
            {
                this._content = value;
            }
        }

        /// <summary>
        ///   <para>The format of the wiki page. Available formats are: markdown (default), rdoc, asciidoc and org</para>
        /// </summary>
        public WikiPageFormat? Format
        {
            get
            {
                return this._format;
            }
            set
            {
                this._format = value;
            }
        }

        /// <summary>
        ///   <para>The ID or URL-encoded path of the project</para>
        /// </summary>
        public ProjectIdOrPathRef? Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        /// <summary>
        ///   <para>The title of the wiki page</para>
        /// </summary>
        public string? Title
        {
            get
            {
                return this._title;
            }
            set
            {
                this._title = value;
            }
        }
    }

    public partial class UpdateWikiPageProjectWikiRequest
    {
        private string? _content;

        private WikiPageFormat? _format;

        private ProjectIdOrPathRef? _id;

        private string? _slug;

        private string? _title;

        /// <param name="id">The ID or URL-encoded path of the project</param>
        /// <param name="slug">The slug (a unique string) of the wiki page</param>
        public UpdateWikiPageProjectWikiRequest(ProjectIdOrPathRef? id, string? slug)
        {
            this._id = id;
            this._slug = slug;
        }

        public UpdateWikiPageProjectWikiRequest()
        {
        }

        /// <summary>
        ///   <para>The content of the wiki page</para>
        /// </summary>
        public string? Content
        {
            get
            {
                return this._content;
            }
            set
            {
                this._content = value;
            }
        }

        /// <summary>
        ///   <para>The format of the wiki page. Available formats are: markdown (default), rdoc, asciidoc and org</para>
        /// </summary>
        public WikiPageFormat? Format
        {
            get
            {
                return this._format;
            }
            set
            {
                this._format = value;
            }
        }

        /// <summary>
        ///   <para>The ID or URL-encoded path of the project</para>
        /// </summary>
        public ProjectIdOrPathRef? Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        /// <summary>
        ///   <para>The slug (a unique string) of the wiki page</para>
        /// </summary>
        public string? Slug
        {
            get
            {
                return this._slug;
            }
            set
            {
                this._slug = value;
            }
        }

        /// <summary>
        ///   <para>The title of the wiki page</para>
        /// </summary>
        public string? Title
        {
            get
            {
                return this._title;
            }
            set
            {
                this._title = value;
            }
        }
    }

    public partial class DeleteWikiPageProjectWikiRequest
    {
        private ProjectIdOrPathRef? _id;

        private string? _slug;

        /// <param name="id">The ID or URL-encoded path of the project</param>
        /// <param name="slug">The slug (a unique string) of the wiki page</param>
        public DeleteWikiPageProjectWikiRequest(ProjectIdOrPathRef? id, string? slug)
        {
            this._id = id;
            this._slug = slug;
        }

        public DeleteWikiPageProjectWikiRequest()
        {
        }

        /// <summary>
        ///   <para>The ID or URL-encoded path of the project</para>
        /// </summary>
        public ProjectIdOrPathRef? Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }

        /// <summary>
        ///   <para>The slug (a unique string) of the wiki page</para>
        /// </summary>
        public string? Slug
        {
            get
            {
                return this._slug;
            }
            set
            {
                this._slug = value;
            }
        }
    }
}