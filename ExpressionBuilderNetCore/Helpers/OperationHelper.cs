using ExpressionBuilderNetCore.Common;
using ExpressionBuilderNetCore.Configuration;
using ExpressionBuilderNetCore.Exceptions;
using ExpressionBuilderNetCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpressionBuilderNetCore.Helpers
{
    /// <summary>
    /// Useful methods regarding <seealso cref="ICondition"></seealso>.
    /// </summary>
    public class ConditionHelper : IConditionHelper
    {
        private static HashSet<ICondition> _conditions;

        private readonly Settings _settings;

        private readonly Dictionary<TypeGroup, HashSet<Type>> TypeGroups;

        static ConditionHelper()
        {
            LoadDefaultConditions();
        }

        /// <summary>
        /// Instantiates a new OperationHelper.
        /// </summary>
        public ConditionHelper()
        {
            _settings = new Settings();
            TypeGroups = new Dictionary<TypeGroup, HashSet<Type>>
            {
                { TypeGroup.Text, new HashSet<Type> { typeof(string), typeof(char) } },
                { TypeGroup.Number, new HashSet<Type> { typeof(int), typeof(uint), typeof(byte), typeof(sbyte), typeof(short), typeof(ushort), typeof(long), typeof(ulong), typeof(Single), typeof(double), typeof(decimal) } },
                { TypeGroup.Boolean, new HashSet<Type> { typeof(bool) } },
                { TypeGroup.Date, new HashSet<Type> { typeof(DateTimeOffset), typeof(DateTime) } },
                { TypeGroup.Nullable, new HashSet<Type> { typeof(Nullable<>), typeof(string) } }
            };
        }

        /// <summary>
        /// List of all operations loaded so far.
        /// </summary>
        public IEnumerable<ICondition> Conditions { get { return _conditions.ToArray(); } }

        /// <summary>
        /// Loads the default operations overwriting any previous changes to the <see cref="Conditions"></see> list.
        /// </summary>
        public static void LoadDefaultConditions()
        {
            var @interface = typeof(ICondition);
            var operationsFound = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => a.DefinedTypes.Any(t => t.Namespace == "ExpressionBuilderNetCore.Conditions"))
                .SelectMany(s => s.GetTypes())
                .Where(p => @interface.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract)
                .Select(t => (ICondition)Activator.CreateInstance(t));
            _conditions = new HashSet<ICondition>(operationsFound, new OperationEqualityComparer());
        }
        /// <summary>
        /// Instantiates an IOperation given its name.
        /// </summary>
        /// <param name="operationName">Name of the operation to be instantiated.</param>
        /// <returns></returns>
        public ICondition GetOperationByName(string operationName)
        {
            var operation = Conditions.SingleOrDefault(o => o.Name == operationName && o.Active);

            if (operation == null)
            {
                throw new OperationNotFoundException(operationName);
            }

            return operation;
        }

        /// <summary>
        /// Loads a list of custom operations into the <see cref="Conditions"></see> list.
        /// </summary>
        /// <param name="operations">List of operations to load.</param>
        public void LoadConditions(List<ICondition> operations)
        {
            LoadConditions(operations, false);
        }

        /// <summary>
        /// Loads a list of custom operations into the <see cref="Conditions"></see> list.
        /// </summary>
        /// <param name="operations">List of operations to load.</param>
        /// <param name="overloadExisting">Specifies that any matching pre-existing operations should be replaced by the ones from the list. (Useful to overwrite the default operations)</param>
        public void LoadConditions(List<ICondition> operations, bool overloadExisting)
        {
            foreach (var operation in operations)
            {
                DeactivateOperation(operation.Name, overloadExisting);
                _conditions.Add(operation);
            }
        }

        /// <summary>
        /// Retrieves a list of <see cref="ICondition"></see> supported by a type.
        /// </summary>
        /// <param name="type">Type for which supported operations should be retrieved.</param>
        /// <returns></returns>
        public HashSet<ICondition> SupportedConditions(Type type)
        {
            GetCustomSupportedTypes();
            return GetSupportedConditions(type);
        }

        private void DeactivateOperation(string operationName, bool overloadExisting)
        {
            if (!overloadExisting)
            {
                return;
            }

            var op = _conditions.FirstOrDefault(o => string.Compare(o.Name, operationName, StringComparison.InvariantCultureIgnoreCase) == 0);
            if (op != null)
            {
                op.Active = false;
            }
        }

        private void GetCustomSupportedTypes()
        {
            foreach (var supportedType in _settings.SupportedTypes)
            {
                if (supportedType.Type != null)
                {
                    TypeGroups[supportedType.TypeGroup].Add(supportedType.Type);
                }
            }
        }

        private HashSet<ICondition> GetSupportedConditions(Type type)
        {
            var underlyingNullableType = Nullable.GetUnderlyingType(type);
            var typeName = (underlyingNullableType ?? type).Name;

            var supportedConditions = new List<ICondition>();
            if (type.IsArray)
            {
                typeName = type.GetElementType().Name;
                supportedConditions.AddRange(Conditions.Where(o => o.SupportsLists && o.Active));
            }

            var typeGroup = TypeGroup.Default;
            if (TypeGroups.Any(i => i.Value.Any(v => v.Name == typeName)))
            {
                typeGroup = TypeGroups.FirstOrDefault(i => i.Value.Any(v => v.Name == typeName)).Key;
            }

            supportedConditions.AddRange(Conditions.Where(o => o.TypeGroup.HasFlag(typeGroup) && !o.SupportsLists && o.Active));

            if (underlyingNullableType != null)
            {
                supportedConditions.AddRange(Conditions.Where(o => o.TypeGroup.HasFlag(TypeGroup.Nullable) && !o.SupportsLists && o.Active));
            }

            return new HashSet<ICondition>(supportedConditions);
        }
    }
}