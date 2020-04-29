using ExpressionBuilderNetCore.Common;
using System.Linq.Expressions;

namespace ExpressionBuilderNetCore.Conditions
{
    /// <summary>
    /// Operation representing an "greater than or equal" comparison.
    /// </summary>
    public class GreaterThanOrEqualTo : ConditionBase
    {
        /// <inheritdoc />
        public GreaterThanOrEqualTo()
            : base("GreaterThanOrEqualTo", 1, TypeGroup.Number | TypeGroup.Date) { }

        /// <inheritdoc />
        public override Expression GetExpression(MemberExpression member, ConstantExpression constant1, ConstantExpression constant2)
        {
            return Expression.GreaterThanOrEqual(member, constant1);
        }

        public override Expression GetExpression(Expression member, ConstantExpression constant1, ConstantExpression constant2)
        {
            return Expression.GreaterThanOrEqual(member, constant1);
        }
    }
}