using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using Meziantou.GitLab.Internals;
using Meziantou.GitLab.Serialization;

namespace Meziantou.GitLab.Core
{
    public partial class GitLabObject : IDynamicMetaObjectProvider
    {
        private DynamicJsonElement? _dynamicMetaObject;

        protected virtual DynamicMetaObject GetMetaObject(Expression parameter)
        {
            // https://github.com/dotnet/runtime/issues/29690
            // https://stackoverflow.com/questions/17600466/using-dynamicobject-idynamicmetaobjectprovider-as-a-component-of-a-static-type
            // https://stackoverflow.com/questions/20745780/idynamicmetaobjectprovider-getmetaobject-is-not-always-called
            if (_dynamicMetaObject == null)
            {
                _dynamicMetaObject = DynamicJsonElement.From(JsonObject, JsonSerialization.Options);
            }

            var restrictions = BindingRestrictions.GetTypeRestriction(parameter, GetType());
            var fieldInfo = typeof(GitLabObject).GetField(nameof(_dynamicMetaObject), BindingFlags.NonPublic | BindingFlags.Instance);
            Debug.Assert(fieldInfo != null);

            return new DelegatingDynamicMetaObject(parameter, restrictions, this, fieldInfo);
        }

        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter) => GetMetaObject(parameter);

        private sealed class DelegatingDynamicMetaObject : DynamicMetaObject
        {
            private readonly DynamicMetaObject _innerMetaObject;

            public DelegatingDynamicMetaObject(Expression expr, BindingRestrictions restrictions, object value, FieldInfo fieldInfo)
                : base(expr, restrictions, value)
            {
                var innerObject = fieldInfo.GetValue(value);
                var innerDynamicProvider = (IDynamicMetaObjectProvider?)innerObject;
                Debug.Assert(innerDynamicProvider != null);
                _innerMetaObject = innerDynamicProvider.GetMetaObject(Expression.Field(Expression.Convert(Expression, LimitType), fieldInfo));
            }

            public override DynamicMetaObject BindBinaryOperation(BinaryOperationBinder binder, DynamicMetaObject arg) => _innerMetaObject.BindBinaryOperation(binder, arg);
            public override DynamicMetaObject BindConvert(ConvertBinder binder) => _innerMetaObject.BindConvert(binder);
            public override DynamicMetaObject BindCreateInstance(CreateInstanceBinder binder, DynamicMetaObject[] args) => _innerMetaObject.BindCreateInstance(binder, args);
            public override DynamicMetaObject BindDeleteIndex(DeleteIndexBinder binder, DynamicMetaObject[] indexes) => _innerMetaObject.BindDeleteIndex(binder, indexes);
            public override DynamicMetaObject BindDeleteMember(DeleteMemberBinder binder) => _innerMetaObject.BindDeleteMember(binder);
            public override DynamicMetaObject BindGetIndex(GetIndexBinder binder, DynamicMetaObject[] indexes) => _innerMetaObject.BindGetIndex(binder, indexes);
            public override DynamicMetaObject BindGetMember(GetMemberBinder binder) => _innerMetaObject.BindGetMember(binder);
            public override DynamicMetaObject BindInvoke(InvokeBinder binder, DynamicMetaObject[] args) => _innerMetaObject.BindInvoke(binder, args);
            public override DynamicMetaObject BindInvokeMember(InvokeMemberBinder binder, DynamicMetaObject[] args) => _innerMetaObject.BindInvokeMember(binder, args);
            public override DynamicMetaObject BindSetIndex(SetIndexBinder binder, DynamicMetaObject[] indexes, DynamicMetaObject value) => _innerMetaObject.BindSetIndex(binder, indexes, value);
            public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value) => _innerMetaObject.BindSetMember(binder, value);
            public override DynamicMetaObject BindUnaryOperation(UnaryOperationBinder binder) => _innerMetaObject.BindUnaryOperation(binder);
            public override IEnumerable<string> GetDynamicMemberNames() => _innerMetaObject.GetDynamicMemberNames();
        }
    }
}
