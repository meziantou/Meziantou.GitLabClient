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
        Meziantou.GitLab.IGitLabToDosClient ToDos
        {
            get;
        }
    }

    public partial interface IGitLabToDosClient
    {
        /// <summary>
        ///   <para>URL: <c>GET /todos</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/todos.html#get-a-list-of-to-do-items" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        Meziantou.GitLab.PagedResponse<Todo> GetTodos(Meziantou.GitLab.GetTodosToDoRequest request, Meziantou.GitLab.RequestOptions? requestOptions = default(Meziantou.GitLab.RequestOptions));

        /// <summary>
        ///   <para>URL: <c>POST /todos/mark_as_done</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/todos.html#mark-all-to-do-items-as-done" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task MarkAllTodosAsDoneAsync(Meziantou.GitLab.MarkAllTodosAsDoneToDoRequest request, Meziantou.GitLab.RequestOptions? requestOptions = default(Meziantou.GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));

        /// <summary>
        ///   <para>URL: <c>POST /todos/:id/mark_as_done</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/todos.html#mark-a-to-do-item-as-done" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<Todo> MarkTodoAsDoneAsync(Meziantou.GitLab.MarkTodoAsDoneToDoRequest request, Meziantou.GitLab.RequestOptions? requestOptions = default(Meziantou.GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken));
    }

    public partial class GitLabClient : Meziantou.GitLab.IGitLabToDosClient
    {
        /// <summary>
        ///   <para>URL: <c>GET /todos</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/todos.html#get-a-list-of-to-do-items" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        Meziantou.GitLab.PagedResponse<Todo> Meziantou.GitLab.IGitLabToDosClient.GetTodos(Meziantou.GitLab.GetTodosToDoRequest request, Meziantou.GitLab.RequestOptions? requestOptions)
        {
            return this.ToDos_GetTodos(request, requestOptions);
        }

        /// <summary>
        ///   <para>URL: <c>POST /todos/mark_as_done</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/todos.html#mark-all-to-do-items-as-done" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task Meziantou.GitLab.IGitLabToDosClient.MarkAllTodosAsDoneAsync(Meziantou.GitLab.MarkAllTodosAsDoneToDoRequest request, Meziantou.GitLab.RequestOptions? requestOptions, System.Threading.CancellationToken cancellationToken)
        {
            return this.ToDos_MarkAllTodosAsDoneAsync(request, requestOptions, cancellationToken);
        }

        /// <summary>
        ///   <para>URL: <c>POST /todos/:id/mark_as_done</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/todos.html#mark-a-to-do-item-as-done" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        System.Threading.Tasks.Task<Todo> Meziantou.GitLab.IGitLabToDosClient.MarkTodoAsDoneAsync(Meziantou.GitLab.MarkTodoAsDoneToDoRequest request, Meziantou.GitLab.RequestOptions? requestOptions, System.Threading.CancellationToken cancellationToken)
        {
            return this.ToDos_MarkTodoAsDoneAsync(request, requestOptions, cancellationToken);
        }

        public Meziantou.GitLab.IGitLabToDosClient ToDos
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        ///   <para>URL: <c>GET /todos</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/todos.html#get-a-list-of-to-do-items" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        private Meziantou.GitLab.PagedResponse<Todo> ToDos_GetTodos(Meziantou.GitLab.GetTodosToDoRequest request, Meziantou.GitLab.RequestOptions? requestOptions = default(Meziantou.GitLab.RequestOptions))
        {
            string url = Meziantou.GitLab.GitLabClient.ToDos_GetTodos_BuildUrl(request);
            return new Meziantou.GitLab.PagedResponse<Todo>(this, url, requestOptions);
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Reliability", "CA2000:Dispose objects before losing scope", Justification = "The rule doesn't understand ref struct")]
        private static string ToDos_GetTodos_BuildUrl(Meziantou.GitLab.GetTodosToDoRequest request)
        {
            string url;
            using (Meziantou.GitLab.Internals.UrlBuilder urlBuilder = new Meziantou.GitLab.Internals.UrlBuilder())
            {
                urlBuilder.Append("todos");
                char separator = '?';
                if (request.Action.HasValue)
                {
                    urlBuilder.Append(separator);
                    separator = '&';
                    urlBuilder.Append("action=");
                    urlBuilder.AppendParameter(request.Action.GetValueOrDefault());
                }

                if (request.AuthorId.HasValue)
                {
                    urlBuilder.Append(separator);
                    separator = '&';
                    urlBuilder.Append("author_id=");
                    urlBuilder.AppendParameter(request.AuthorId.GetValueOrDefault().Value);
                }

                if (request.ProjectId.HasValue)
                {
                    urlBuilder.Append(separator);
                    separator = '&';
                    urlBuilder.Append("project_id=");
                    urlBuilder.AppendParameter(request.ProjectId.GetValueOrDefault().Value);
                }

                if (request.GroupId.HasValue)
                {
                    urlBuilder.Append(separator);
                    separator = '&';
                    urlBuilder.Append("group_id=");
                    urlBuilder.AppendParameter(request.GroupId.GetValueOrDefault().Value);
                }

                if (request.State.HasValue)
                {
                    urlBuilder.Append(separator);
                    separator = '&';
                    urlBuilder.Append("state=");
                    urlBuilder.AppendParameter(request.State.GetValueOrDefault());
                }

                url = urlBuilder.ToString();
            }

            return url;
        }

        /// <summary>
        ///   <para>URL: <c>POST /todos/mark_as_done</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/todos.html#mark-all-to-do-items-as-done" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        private async System.Threading.Tasks.Task ToDos_MarkAllTodosAsDoneAsync(Meziantou.GitLab.MarkAllTodosAsDoneToDoRequest request, Meziantou.GitLab.RequestOptions? requestOptions = default(Meziantou.GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            string url = Meziantou.GitLab.GitLabClient.ToDos_MarkAllTodosAsDoneAsync_BuildUrl();
            using (System.Net.Http.HttpRequestMessage requestMessage = new System.Net.Http.HttpRequestMessage())
            {
                requestMessage.Method = System.Net.Http.HttpMethod.Post;
                requestMessage.RequestUri = new System.Uri(url, System.UriKind.RelativeOrAbsolute);
                HttpResponse? response = null;
                try
                {
                    response = await this.SendAsync(requestMessage, requestOptions, cancellationToken).ConfigureAwait(false);
                    await response.EnsureStatusCodeAsync(cancellationToken).ConfigureAwait(false);
                }
                finally
                {
                    if ((response != null))
                    {
                        response.Dispose();
                    }
                }
            }
        }

        private static string ToDos_MarkAllTodosAsDoneAsync_BuildUrl()
        {
            string url;
            url = "todos/mark_as_done";
            return url;
        }

        /// <summary>
        ///   <para>URL: <c>POST /todos/:id/mark_as_done</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/todos.html#mark-a-to-do-item-as-done" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        private async System.Threading.Tasks.Task<Todo> ToDos_MarkTodoAsDoneAsync(Meziantou.GitLab.MarkTodoAsDoneToDoRequest request, Meziantou.GitLab.RequestOptions? requestOptions = default(Meziantou.GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            string url = Meziantou.GitLab.GitLabClient.ToDos_MarkTodoAsDoneAsync_BuildUrl(request);
            using (System.Net.Http.HttpRequestMessage requestMessage = new System.Net.Http.HttpRequestMessage())
            {
                requestMessage.Method = System.Net.Http.HttpMethod.Post;
                requestMessage.RequestUri = new System.Uri(url, System.UriKind.RelativeOrAbsolute);
                HttpResponse? response = null;
                try
                {
                    response = await this.SendAsync(requestMessage, requestOptions, cancellationToken).ConfigureAwait(false);
                    await response.EnsureStatusCodeAsync(cancellationToken).ConfigureAwait(false);
                    Todo? result = await response.ToObjectAsync<Todo>(cancellationToken).ConfigureAwait(false);
                    if ((result == null))
                    {
                        throw new Meziantou.GitLab.GitLabException(response.RequestMethod, response.RequestUri, response.StatusCode, "The response cannot be converted to 'Todo' because the body is null or empty");
                    }

                    return result;
                }
                finally
                {
                    if ((response != null))
                    {
                        response.Dispose();
                    }
                }
            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Reliability", "CA2000:Dispose objects before losing scope", Justification = "The rule doesn't understand ref struct")]
        private static string ToDos_MarkTodoAsDoneAsync_BuildUrl(Meziantou.GitLab.MarkTodoAsDoneToDoRequest request)
        {
            string url;
            using (Meziantou.GitLab.Internals.UrlBuilder urlBuilder = new Meziantou.GitLab.Internals.UrlBuilder())
            {
                urlBuilder.Append("todos/");
                if (request.Id.HasValue)
                {
                    urlBuilder.AppendParameter(request.Id.GetValueOrDefault().Value);
                }

                urlBuilder.Append("/mark_as_done");
                url = urlBuilder.ToString();
            }

            return url;
        }
    }

    public static partial class GitLabClientExtensions
    {
        /// <summary>
        ///   <para>URL: <c>GET /todos</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/todos.html#get-a-list-of-to-do-items" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        public static Meziantou.GitLab.PagedResponse<Todo> GetTodos(this Meziantou.GitLab.IGitLabToDosClient client, TodoAction? action = default(TodoAction?), UserIdRef? authorId = default(UserIdRef?), ProjectIdRef? projectId = default(ProjectIdRef?), GroupIdRef? groupId = default(GroupIdRef?), TodoState? state = default(TodoState?), Meziantou.GitLab.RequestOptions? requestOptions = default(Meziantou.GitLab.RequestOptions))
        {
            Meziantou.GitLab.GetTodosToDoRequest request = new Meziantou.GitLab.GetTodosToDoRequest();
            request.Action = action;
            request.AuthorId = authorId;
            request.ProjectId = projectId;
            request.GroupId = groupId;
            request.State = state;
            return client.GetTodos(request, requestOptions);
        }

        /// <summary>
        ///   <para>URL: <c>POST /todos/mark_as_done</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/todos.html#mark-all-to-do-items-as-done" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task MarkAllTodosAsDoneAsync(this Meziantou.GitLab.IGitLabToDosClient client, Meziantou.GitLab.RequestOptions? requestOptions = default(Meziantou.GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.MarkAllTodosAsDoneToDoRequest request = new Meziantou.GitLab.MarkAllTodosAsDoneToDoRequest();
            return client.MarkAllTodosAsDoneAsync(request, requestOptions, cancellationToken);
        }

        /// <summary>
        ///   <para>URL: <c>POST /todos/:id/mark_as_done</c></para>
        ///   <para>
        ///     <seealso href="https://docs.gitlab.com/ee/api/todos.html#mark-a-to-do-item-as-done" />
        ///   </para>
        /// </summary>
        /// <param name="requestOptions">Options of the request</param>
        /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation</param>
        public static System.Threading.Tasks.Task<Todo> MarkTodoAsDoneAsync(this Meziantou.GitLab.IGitLabToDosClient client, TodoIdRef id, Meziantou.GitLab.RequestOptions? requestOptions = default(Meziantou.GitLab.RequestOptions), System.Threading.CancellationToken cancellationToken = default(System.Threading.CancellationToken))
        {
            Meziantou.GitLab.MarkTodoAsDoneToDoRequest request = new Meziantou.GitLab.MarkTodoAsDoneToDoRequest(id);
            return client.MarkTodoAsDoneAsync(request, requestOptions, cancellationToken);
        }
    }

    public partial class GetTodosToDoRequest
    {
        private TodoAction? _action;

        private UserIdRef? _authorId;

        private GroupIdRef? _groupId;

        private ProjectIdRef? _projectId;

        private TodoState? _state;

        public GetTodosToDoRequest()
        {
        }

        /// <summary>
        ///   <para>The action to be filtered. Can be assigned, mentioned, build_failed, marked, approval_required, unmergeable, directly_addressed or merge_train_removed.</para>
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnoreAttribute]
        public TodoAction? Action
        {
            get
            {
                return this._action;
            }
            set
            {
                this._action = value;
            }
        }

        /// <summary>
        ///   <para>The ID of an author</para>
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnoreAttribute]
        public UserIdRef? AuthorId
        {
            get
            {
                return this._authorId;
            }
            set
            {
                this._authorId = value;
            }
        }

        /// <summary>
        ///   <para>The ID of a group</para>
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnoreAttribute]
        public GroupIdRef? GroupId
        {
            get
            {
                return this._groupId;
            }
            set
            {
                this._groupId = value;
            }
        }

        /// <summary>
        ///   <para>The ID of a project</para>
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnoreAttribute]
        public ProjectIdRef? ProjectId
        {
            get
            {
                return this._projectId;
            }
            set
            {
                this._projectId = value;
            }
        }

        /// <summary>
        ///   <para>The state of the to-do item. Can be either pending or done</para>
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnoreAttribute]
        public TodoState? State
        {
            get
            {
                return this._state;
            }
            set
            {
                this._state = value;
            }
        }
    }

    public partial class MarkTodoAsDoneToDoRequest
    {
        private TodoIdRef? _id;

        /// <param name="id">The ID of to-do item</param>
        public MarkTodoAsDoneToDoRequest(TodoIdRef? id)
        {
            this._id = id;
        }

        public MarkTodoAsDoneToDoRequest()
        {
        }

        /// <summary>
        ///   <para>The ID of to-do item</para>
        /// </summary>
        [System.Text.Json.Serialization.JsonIgnoreAttribute]
        public TodoIdRef? Id
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

    public partial class MarkAllTodosAsDoneToDoRequest
    {
        public MarkAllTodosAsDoneToDoRequest()
        {
        }
    }
}
