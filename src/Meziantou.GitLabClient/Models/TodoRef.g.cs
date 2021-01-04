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
    [System.Text.Json.Serialization.JsonConverterAttribute(typeof(Meziantou.GitLab.Serialization.GitLabObjectObjectReferenceJsonConverterFactory))]
    public readonly partial struct TodoRef : Meziantou.GitLab.Internals.IGitLabObjectReference<long>, System.IEquatable<Meziantou.GitLab.TodoRef>
    {
        private readonly long _value;

        private TodoRef(long todoId)
        {
            this._value = todoId;
        }

        private TodoRef(Todo todo)
        {
            if ((todo == null))
            {
                throw new System.ArgumentNullException(nameof(todo));
            }

            this._value = todo.Id;
        }

        public long Value
        {
            get
            {
                return this._value;
            }
        }

        public override bool Equals(object? obj)
        {
            if ((obj is Meziantou.GitLab.TodoRef))
            {
                return this.Equals(((Meziantou.GitLab.TodoRef)obj));
            }
            else
            {
                return false;
            }
        }

        public bool Equals(Meziantou.GitLab.TodoRef other)
        {
            return object.Equals(this.Value, other.Value);
        }

        public static Meziantou.GitLab.TodoRef FromTodo(Todo todo)
        {
            if ((todo == null))
            {
                throw new System.ArgumentNullException(nameof(todo));
            }

            return new Meziantou.GitLab.TodoRef(todo);
        }

        public static Meziantou.GitLab.TodoRef FromTodoId(long todoId)
        {
            return new Meziantou.GitLab.TodoRef(todoId);
        }

        public override int GetHashCode()
        {
            return System.HashCode.Combine(this.Value);
        }

        public override string ToString()
        {
            return this.Value.ToString(System.Globalization.CultureInfo.InvariantCulture);
        }

        public static implicit operator Meziantou.GitLab.TodoRef(long todoId)
        {
            return Meziantou.GitLab.TodoRef.FromTodoId(todoId);
        }

        public static implicit operator Meziantou.GitLab.TodoRef?(long? todoId)
        {
            if (todoId.HasValue)
            {
                return Meziantou.GitLab.TodoRef.FromTodoId(todoId.Value);
            }
            else
            {
                return null;
            }
        }

        public static implicit operator Meziantou.GitLab.TodoRef(Todo todo)
        {
            return Meziantou.GitLab.TodoRef.FromTodo(todo);
        }

        public static implicit operator Meziantou.GitLab.TodoRef?(Todo? todo)
        {
            if (object.ReferenceEquals(todo, null))
            {
                return null;
            }
            else
            {
                return Meziantou.GitLab.TodoRef.FromTodo(todo);
            }
        }

        public static bool operator !=(Meziantou.GitLab.TodoRef a, Meziantou.GitLab.TodoRef b)
        {
            return (!(a == b));
        }

        public static bool operator ==(Meziantou.GitLab.TodoRef a, Meziantou.GitLab.TodoRef b)
        {
            return System.Collections.Generic.EqualityComparer<Meziantou.GitLab.TodoRef>.Default.Equals(a, b);
        }
    }
}
