using System;
using System.Linq;
using Meziantou.Framework;

namespace Meziantou.GitLabClient.Generator.GitLabModels
{
    internal static partial class GitLabModelBuilder
    {
        public static Project Create()
        {
            var project = new Project();
            Enumerations.Create(project);
            Entities.Create(project);
            EntityRefs.Create(project);

            typeof(GitLabModelBuilder).Assembly.GetTypes()
                .Where(t => typeof(IGitLabClientDescriptor).IsAssignableFrom(t) && t.IsClass)
                .ForEach(t =>
                {
                    var instance = (IGitLabClientDescriptor)Activator.CreateInstance(t);
                    instance.Create(project);
                });

            return project;
        }

        //Project.AddMethodGroup("Todo",
        //    new[]
        //    {
        //        new Method("GetTodos", "todos")
        //        {
        //            Documentation = new Documentation
        //            {
        //                Summary = "Returns a list of todos. When no filter is applied, it returns all pending todos for the current user. Different filters allow the user to precise the request.",
        //                HelpLink = "https://docs.gitlab.com/ee/api/todos.html#get-a-list-of-todos",
        //            },
        //            ReturnType = Entities.Todo,
        //            MethodType = MethodType.GetPaged,
        //            Parameters =
        //            {
        //                new MethodParameter("action", Enumerations.TodoAction.MakeNullable()) { IsOptional = true },
        //            },
        //        },
        //        new Method("MarkTodoAsDone", "todos/:todo/mark_as_done")
        //        {
        //            Documentation = new Documentation
        //            {
        //                Summary = "Marks a single pending todo given by its ID for the current user as done.",
        //                HelpLink = "https://docs.gitlab.com/ee/api/todos.html#mark-a-todo-as-done",
        //            },
        //            ReturnType = Entities.Todo,
        //            MethodType = MethodType.Post,
        //            Parameters =
        //            {
        //                new MethodParameter("todo", EntityRefs.TodoIdRef),
        //            },
        //        },
        //        new Method("MarkAllTodosAsDone", "todos/mark_as_done")
        //        {
        //            Documentation = new Documentation
        //            {
        //                Summary = "Marks all pending todos for the current user as done.",
        //                HelpLink = "https://docs.gitlab.com/ee/api/todos.html#mark-a-todo-as-done",
        //            },
        //            MethodType = MethodType.Post,
        //        },
        //    });
    }
}
