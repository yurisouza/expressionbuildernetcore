using ExpressionBuilderNetCore.Common;
using System.Linq.Expressions;
using System.Reflection;
using System;

namespace ExpressionBuilderNetCore.Conditions
{
    /// <summary>
    /// Operation that checks for the non-existence of a substring within another string.
    /// </summary>
    public class DoesNotContain : ConditionBase
    {
        private readonly MethodInfo stringContainsMethod = typeof(string).GetMethod("Contains", new[] { typeof(string) });

        /// <inheritdoc />
        public DoesNotContain()
            : base("DoesNotContain", 1, TypeGroup.Text) { }

        /// <inheritdoc />
        public override Expression GetExpression(MemberExpression member, ConstantExpression constant1, ConstantExpression constant2)
        {
            Expression constant = constant1.TrimToLower();

            return Expression.Not(Expression.Call(member.TrimToLower(), stringContainsMethod, constant))
                   .AddNullCheck(member);
        }

        public override Expression GetExpression(Expression member, ConstantExpression constant1, ConstantExpression constant2)
        {
            throw new NotImplementedException("Verify the parameters.");
        }
    }
}