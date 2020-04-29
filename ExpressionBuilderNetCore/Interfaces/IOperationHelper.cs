using System;
using System.Collections.Generic;

namespace ExpressionBuilderNetCore.Interfaces
{
    /// <summary>
    /// Useful methods regarding <seealso cref="ICondition"></seealso>.
    /// </summary>
    public interface IConditionHelper
    {
        #region Properties

        /// <summary>
        /// List of all operations loaded so far.
        /// </summary>
        IEnumerable<ICondition> Conditions { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Retrieves a list of <see cref="Condition"></see> supported by a type.
        /// </summary>
        /// <param name="type">Type for which supported operations should be retrieved.</param>
        /// <returns></returns>
        HashSet<ICondition> SupportedConditions(Type type);

        /// <summary>
        /// Instantiates an IOperation given its name.
        /// </summary>
        /// <param name="operationName">Name of the operation to be instantiated.</param>
        /// <returns></returns>
        ICondition GetOperationByName(string operationName);

        /// <summary>
        /// Loads a list of custom operations into the <see cref="Conditions"></see> list.
        /// </summary>
        /// <param name="operations">List of operations to load.</param>
        void LoadConditions(List<ICondition> operations);

        /// <summary>
        /// Loads a list of custom operations into the <see cref="Conditions"></see> list.
        /// </summary>
        /// <param name="operations">List of operations to load.</param>
        /// <param name="overloadExisting">Specifies that any matching pre-existing operations should be replaced by the ones from the list. (Useful to overwrite the default operations)</param>
        void LoadConditions(List<ICondition> operations, bool overloadExisting);

        #endregion Methods
    }
}