namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal sealed class TodosClient : GitLabClientBuilder
    {
        protected override void Create(MethodGroup methodGroup)
        {
            methodGroup.AddMethod("GetTodos", MethodType.GetPaged, "/todos", "https://docs.gitlab.com/ee/api/todos.html#get-a-list-of-todos")
                .WithReturnType(Models.Todo)
                .AddOptionalParameter("action", Models.TodoAction)
                ;

            methodGroup.AddMethod("MarkTodoAsDone", MethodType.Post, "/todos/:todo_id/mark_as_done", "https://docs.gitlab.com/ee/api/todos.html#mark-a-todo-as-done")
                .WithReturnType(Models.Todo)
                .AddRequiredParameter("todo_id", Models.TodoRef)
                ;

            methodGroup.AddMethod("MarkAllTodosAsDone", MethodType.Post, "/todos/mark_as_done", "https://docs.gitlab.com/ee/api/todos.html#mark-all-todos-as-done")
                ;
        }
    }
}
