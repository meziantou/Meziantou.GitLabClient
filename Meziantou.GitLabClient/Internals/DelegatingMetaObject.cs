﻿using System.Collections.Generic;
using System.Dynamic;
using System.Linq.Expressions;

namespace Meziantou.GitLab
{
    internal sealed class DelegatingMetaObject : DynamicMetaObject
    {
        private readonly IDynamicMetaObjectProvider _innerProvider;
        private readonly DynamicMetaObject _innerMetaObject;

        public DelegatingMetaObject(IDynamicMetaObjectProvider innerProvider, Expression expr, BindingRestrictions restrictions, object value)
            : base(expr, restrictions, value)
        {
            _innerProvider = innerProvider;
            _innerMetaObject = _innerProvider.GetMetaObject(Expression.Constant(_innerProvider));
        }

        public override DynamicMetaObject BindInvokeMember(InvokeMemberBinder binder, DynamicMetaObject[] args)
        {
            return _innerMetaObject.BindInvokeMember(binder, args);
        }

        public override DynamicMetaObject BindGetMember(GetMemberBinder binder)
        {
            return _innerMetaObject.BindGetMember(binder);
        }

        public override DynamicMetaObject BindBinaryOperation(BinaryOperationBinder binder, DynamicMetaObject arg)
        {
            return _innerMetaObject.BindBinaryOperation(binder, arg);
        }

        public override DynamicMetaObject BindConvert(ConvertBinder binder)
        {
            return _innerMetaObject.BindConvert(binder);
        }

        public override DynamicMetaObject BindCreateInstance(CreateInstanceBinder binder, DynamicMetaObject[] args)
        {
            return null;
        }

        public override DynamicMetaObject BindDeleteIndex(DeleteIndexBinder binder, DynamicMetaObject[] indexes)
        {
            return null;
        }

        public override DynamicMetaObject BindDeleteMember(DeleteMemberBinder binder)
        {
            return null;
        }

        public override DynamicMetaObject BindGetIndex(GetIndexBinder binder, DynamicMetaObject[] indexes)
        {
            return _innerMetaObject.BindGetIndex(binder, indexes);
        }

        public override DynamicMetaObject BindInvoke(InvokeBinder binder, DynamicMetaObject[] args)
        {
            return null;
        }

        public override DynamicMetaObject BindSetIndex(SetIndexBinder binder, DynamicMetaObject[] indexes, DynamicMetaObject value)
        {
            return null;
        }

        public override DynamicMetaObject BindSetMember(SetMemberBinder binder, DynamicMetaObject value)
        {
            return null;
        }

        public override DynamicMetaObject BindUnaryOperation(UnaryOperationBinder binder)
        {
            return _innerMetaObject.BindUnaryOperation(binder);
        }

        public override IEnumerable<string> GetDynamicMemberNames()
        {
            return _innerMetaObject.GetDynamicMemberNames();
        }
    }
}
