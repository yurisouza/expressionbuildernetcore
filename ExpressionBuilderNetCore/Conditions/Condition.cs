using ExpressionBuilderNetCore.Helpers;
using ExpressionBuilderNetCore.Interfaces;
using System.Collections.Generic;

namespace ExpressionBuilderNetCore.Conditions
{
    /// <summary>
    /// Exposes the default operations supported by the <seealso cref="Builders.FilterBuilder" />.
    /// </summary>
    public static class Condition
    {
        private static ConditionHelper _conditionHelper;

        static Condition()
        {
            _conditionHelper = new ConditionHelper();
        }

        /// <summary>
        /// Operation representing a range comparison.
        /// </summary>
        public static ICondition Between { get { return new Between(); } }

        /// <summary>
        /// Operation representing a string "Contains" method call.
        /// </summary>
        public static ICondition Contains { get { return new Contains(); } }

        /// <summary>
        /// Operation that checks for the non-existence of a substring within another string.
        /// </summary>
        public static ICondition DoesNotContain { get { return new DoesNotContain(); } }

        /// <summary>
        /// Operation representing a string "EndsWith" method call.
        /// </summary>
        public static ICondition EndsWith { get { return new EndsWith(); } }

        /// <summary>
        /// Operation representing an equality comparison.
        /// </summary>
        public static ICondition EqualTo { get { return new EqualTo(); } }

        /// <summary>
        /// Operation representing an "greater than" comparison.
        /// </summary>
        public static ICondition GreaterThan { get { return new GreaterThan(); } }

        /// <summary>
        /// Operation representing an "greater than or equal" comparison.
        /// </summary>
        public static ICondition GreaterThanOrEqualTo { get { return new GreaterThanOrEqualTo(); } }

        /// <summary>
        /// Operation representing a list "Contains" method call.
        /// </summary>
        public static ICondition In { get { return new In(); } }

        /// <summary>
        /// Operation representing a check for an empty string.
        /// </summary>
        public static ICondition IsEmpty { get { return new IsEmpty(); } }

        /// <summary>
        /// Operation representing a check for a non-empty string.
        /// </summary>
        public static ICondition IsNotEmpty { get { return new IsNotEmpty(); } }

        /// <summary>
        /// Operation representing a "not-null" check.
        /// </summary>
        public static ICondition IsNotNull { get { return new IsNotNull(); } }

        /// <summary>
        /// Operation representing a "not null nor whitespace" check.
        /// </summary>
        public static ICondition IsNotNullNorWhiteSpace { get { return new IsNotNullNorWhiteSpace(); } }

        /// <summary>
        /// Operation representing a null check.
        /// </summary>
        public static ICondition IsNull { get { return new IsNull(); } }

        /// <summary>
        /// Operation representing a "null or whitespace" check.
        /// </summary>
        public static ICondition IsNullOrWhiteSpace { get { return new IsNullOrWhiteSpace(); } }

        /// <summary>
        /// Operation representing an "less than" comparison.
        /// </summary>
        public static ICondition LessThan { get { return new LessThan(); } }

        /// <summary>
        /// Operation representing an "less than or equal" comparison.
        /// </summary>
        public static ICondition LessThanOrEqualTo { get { return new LessThanOrEqualTo(); } }

        /// <summary>
        /// Operation representing an inequality comparison.
        /// </summary>
        public static ICondition NotEqualTo { get { return new NotEqualTo(); } }

        /// <summary>
        /// Operation representing a string "StartsWith" method call.
        /// </summary>
        public static ICondition StartsWith { get { return new StartsWith(); } }

        /// <summary>
        /// Operation representing the inverse of a list "Contains" method call.
        /// </summary>
        public static ICondition NotIn { get { return new NotIn(); } }

        /// <summary>
        /// Instantiates an IOperation given its name.
        /// </summary>
        /// <param name="operationName">Name of the operation to be instantiated.</param>
        /// <returns></returns>
        public static ICondition ByName(string operationName)
        {
            return _conditionHelper.GetOperationByName(operationName);
        }

        /// <summary>
        /// Loads a list of custom operations into the <see cref="Conditions"></see> list.
        /// </summary>
        /// <param name="operations">List of operations to load.</param>
        /// <param name="overloadExisting">Specifies that any matching pre-existing operations should be replaced by the ones from the list. (Useful to overwrite the default operations)</param>
        public static void LoadConditions(List<ICondition> operations, bool overloadExisting = false)
        {
            _conditionHelper.LoadConditions(operations, overloadExisting);
        }
    }
}