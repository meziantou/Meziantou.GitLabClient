namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal sealed class ClientTodo : IGitLabClientDescriptor
    {
        public void Create(Project project)
        {
            var group = project.AddMethodGroup("Todos");

            group.AddMethod("GetTodos", MethodType.GetPaged, "/todos", "https://docs.gitlab.com/ee/api/todos.html#get-a-list-of-todos")
                .WithReturnType(Models.Todo)
                .AddOptionalParameter("action", Models.TodoAction)
                ;

            group.AddMethod("MarkTodoAsDone", MethodType.Post, "/todos/:todo_id/mark_as_done", "https://docs.gitlab.com/ee/api/todos.html#mark-a-todo-as-done")
                .WithReturnType(Models.Todo)
                .AddRequiredParameter("todo_id", EntityRefs.TodoIdRef)
                ;

            group.AddMethod("MarkAllTodosAsDone", MethodType.Post, "/todos/mark_as_done", "https://docs.gitlab.com/ee/api/todos.html#mark-all-todos-as-done")
                ;
        }
    }
}
