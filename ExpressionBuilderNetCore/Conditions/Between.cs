using ExpressionBuilderNetCore.Common;
using System.Linq.Expressions;

namespace ExpressionBuilderNetCore.Conditions
{
    /// <summary>
    /// Operation representing a range comparison.
    /// </summary>
    public class Between : ConditionBase
    {
        /// <inheritdoc />
        public Between()
            : base("Between", 2, TypeGroup.Number | TypeGroup.Date) { }

        /// <inheritdoc />
        public override Expression GetExpression(MemberExpression member, ConstantExpression constant1, ConstantExpression constant2)
        {
            var left = Expression.GreaterThanOrEqual(member, constant1);
            var right = Expression.LessThanOrEqual(member, constant2);

            return Expression.AndAlso(left, right);
        }

        public override Expression GetExpression(Expression member, ConstantExpression constant1, ConstantExpression constant2)
        {
            var left = Expression.GreaterThanOrEqual(member, constant1);
            var right = Expression.LessThanOrEqual(member, constant2);

            return Expression.AndAlso(left, right);
        }
    }
}