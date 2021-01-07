using System.Dynamic;

namespace Meziantou.GitLab.Internals
{
    internal static class ConvertBinderExtensions
    {
        public static bool IsType<T>(this ConvertBinder binder) => binder.Type == typeof(T);

        public static bool IsValueType<T>(this ConvertBinder binder)
            where T : struct
        {
            return binder.IsType<T>() || binder.Type == typeof(T?);
        }
    }
}
