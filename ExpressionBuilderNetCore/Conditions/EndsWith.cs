using ExpressionBuilderNetCore.Common;
using System.Linq.Expressions;
using System.Reflection;
using System;

namespace ExpressionBuilderNetCore.Conditions
{
    /// <summary>
    /// Operation representing a string "EndsWith" method call.
    /// </summary>
    public class EndsWith : ConditionBase
    {
        private readonly MethodInfo endsWithMethod = typeof(string).GetMethod("EndsWith", new[] { typeof(string) });

        /// <inheritdoc />
        public EndsWith()
            : base("EndsWith", 1, TypeGroup.Text) { }

        /// <inheritdoc />
        public override Expression GetExpression(MemberExpression member, ConstantExpression constant1, ConstantExpression constant2)
        {
            Expression constant = constant1.TrimToLower();

            return Expression.Call(member.TrimToLower(), endsWithMethod, constant)
                   .AddNullCheck(member);
        }

        public override Expression GetExpression(Expression member, ConstantExpression constant1, ConstantExpression constant2)
        {
            throw new NotImplementedException("Verify the parameters.");
        }
    }
}