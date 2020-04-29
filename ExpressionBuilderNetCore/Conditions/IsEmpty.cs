using ExpressionBuilderNetCore.Common;
using System.Linq.Expressions;
using System;

namespace ExpressionBuilderNetCore.Conditions
{
    /// <summary>
    /// Operation representing a check for an empty string.
    /// </summary>
    public class IsEmpty : ConditionBase
    {
        /// <inheritdoc />
        public IsEmpty()
            : base("IsEmpty", 0, TypeGroup.Text) { }

        /// <inheritdoc />
        public override Expression GetExpression(MemberExpression member, ConstantExpression constant1, ConstantExpression constant2)
        {
            return Expression.Equal(member.TrimToLower(), Expression.Constant(string.Empty))
                   .AddNullCheck(member);
        }

        public override Expression GetExpression(Expression member, ConstantExpression constant1, ConstantExpression constant2)
        {
            throw new NotImplementedException("Verify the parameters.");
        }
    }
}