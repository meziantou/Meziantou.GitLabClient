namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal static partial class Enumerations
    {
        public static ModelRef TodoAction { get; private set; }
        public static ModelRef TodoState { get; private set; }
        public static ModelRef TodoType { get; private set; }

        public static void CreateTodo(Project project)
        {
            TodoAction = project.AddStringEnumeration("TodoAction")
                .AddMembers("assigned", "mentioned", "build_failed", "marked", "approval_required", "unmergeable", "directly_addressed");

            TodoState = project.AddStringEnumeration("TodoState")
                .AddMembers("pending", "done");

            TodoType = project.AddStringEnumeration("TodoTargetType")
                .AddMembers("Issue", "MergeRequest", "Commit");
        }
    }

    internal static partial class Entities
    {
        public static EntityBuilder Todo { get; private set; }

        public static void CreateTodo()
        {
            Todo.Configure(entity => entity
                .AddProperty("id", ModelRef.NumberId, PropertyOptions.IsKey)
                .AddProperty("action_name", Enumerations.TodoAction)
                .AddProperty("author", Entities.UserBasic)
                .AddProperty("project", BasicProjectDetails)
                .AddProperty("target_type", Enumerations.TodoType)
                .AddProperty("target_url", ModelRef.Uri)
                .AddProperty("body", ModelRef.String)
                .AddProperty("state", Enumerations.TodoState)
                .AddProperty("created_at", ModelRef.DateTime)
            );
        }
    }

    internal sealed class ClientTodo : IGitLabClientDescriptor
    {
        public void Create(Project project)
        {
            var group = project.AddMethodGroup("Todos");

            group.AddMethod("GetTodos", MethodType.GetPaged, "/todos", "https://docs.gitlab.com/ee/api/todos.html#get-a-list-of-todos")
                .WithReturnType(Entities.Todo)
                .AddOptionalParameter("action", Enumerations.TodoAction)
                ;

            group.AddMethod("MarkTodoAsDone", MethodType.Post, "/todos/:todo_id/mark_as_done", "https://docs.gitlab.com/ee/api/todos.html#mark-a-todo-as-done")
                .WithReturnType(Entities.Todo)
                .AddRequiredParameter("todo_id", EntityRefs.TodoIdRef)
                ;

            group.AddMethod("MarkAllTodosAsDone", MethodType.Post, "/todos/mark_as_done", "https://docs.gitlab.com/ee/api/todos.html#mark-all-todos-as-done")
                ;
        }
    }
}
