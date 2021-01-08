namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal sealed class ToDosClient : GitLabClientBuilder
    {
        protected override void Create(MethodGroup methodGroup)
        {
            methodGroup.AddMethod("GetTodos", MethodType.GetPaged, "/todos", "https://docs.gitlab.com/ee/api/todos.html#get-a-list-of-to-dos")
                .WithReturnType(Models.Todo)
                .AddOptionalParameter("action", Models.TodoAction)
                .AddOptionalParameter("author_id", Models.UserIdRef)
                .AddOptionalParameter("project_id", Models.ProjectIdRef)
                .AddOptionalParameter("group_id", Models.GroupIdRef)
                .AddOptionalParameter("state", Models.TodoState)
                ;

            methodGroup.AddMethod("MarkTodoAsDone", MethodType.Post, "/todos/:id/mark_as_done", "https://docs.gitlab.com/ee/api/todos.html#mark-a-to-do-item-as-done")
                .WithReturnType(Models.Todo)
                .AddRequiredParameter("id", Models.TodoIdRef)
                ;

            methodGroup.AddMethod("MarkAllTodosAsDone", MethodType.Post, "/todos/mark_as_done", "https://docs.gitlab.com/ee/api/todos.html#mark-all-to-dos-as-done")
                ;
        }
    }
}
