﻿using ExpressionBuilderNetCore.Common;
using System.Linq.Expressions;

namespace ExpressionBuilderNetCore.Conditions
{
    /// <summary>
    /// Operation representing an "less than or equal" comparison.
    /// </summary>
    public class LessThanOrEqualTo : ConditionBase
    {
        /// <inheritdoc />
        public LessThanOrEqualTo()
            : base("LessThanOrEqualTo", 1, TypeGroup.Number | TypeGroup.Date) { }

        /// <inheritdoc />
        public override Expression GetExpression(MemberExpression member, ConstantExpression constant1, ConstantExpression constant2)
        {
            return Expression.LessThanOrEqual(member, constant1);
        }

        public override Expression GetExpression(Expression member, ConstantExpression constant1, ConstantExpression constant2)
        {
            return Expression.LessThanOrEqual(member, constant1);
        }
    }
}