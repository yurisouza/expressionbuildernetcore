using ExpressionBuilderNetCore.Common;
using System.Linq.Expressions;
using System;

namespace ExpressionBuilderNetCore.Conditions
{
    /// <summary>
    /// Operation representing a check for a non-empty string.
    /// </summary>
    public class IsNotEmpty : ConditionBase
    {
        /// <inheritdoc />
        public IsNotEmpty()
            : base("IsNotEmpty", 0, TypeGroup.Text) { }

        /// <inheritdoc />
        public override Expression GetExpression(MemberExpression member, ConstantExpression constant1, ConstantExpression constant2)
        {
            return Expression.NotEqual(member.TrimToLower(), Expression.Constant(string.Empty))
                   .AddNullCheck(member);
        }

        public override Expression GetExpression(Expression member, ConstantExpression constant1, ConstantExpression constant2)
        {
            throw new NotImplementedException("Verify the parameters.");
        }
    }
}