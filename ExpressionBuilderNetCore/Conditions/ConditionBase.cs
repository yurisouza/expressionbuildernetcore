using System;
using ExpressionBuilderNetCore.Common;
using ExpressionBuilderNetCore.Interfaces;
using System.Linq.Expressions;

namespace ExpressionBuilderNetCore.Conditions
{
    /// <summary>
    /// Base class for operations.
    /// </summary>
    public abstract class ConditionBase : ICondition, IEquatable<ICondition>
    {
        /// <inheritdoc />
        public string Name { get; }

        /// <inheritdoc />
        public TypeGroup TypeGroup { get; }

        /// <inheritdoc />
        public int NumberOfValues { get; }

        /// <inheritdoc />
        public bool Active { get; set; }

        /// <inheritdoc />
        public bool SupportsLists { get; }

        /// <inheritdoc />
        public bool ExpectNullValues { get; }

        /// <summary>
        /// Instantiates a new operation.
        /// </summary>
        /// <param name="name">Conditions name.</param>
        /// <param name="numberOfValues">Number of values supported by the operation.</param>
        /// <param name="typeGroups">TypeGroup(s) which the operation supports.</param>
        /// <param name="active">Determines if the operation is active.</param>
        /// <param name="supportsLists">Determines if the operation supports arrays.</param>
        /// <param name="expectNullValues"></param>
        protected ConditionBase(string name, int numberOfValues, TypeGroup typeGroups, bool active = true, bool supportsLists = false, bool expectNullValues = false)
        {
            Name = name;
            NumberOfValues = numberOfValues;
            TypeGroup = typeGroups;
            Active = active;
            SupportsLists = supportsLists;
            ExpectNullValues = expectNullValues;
        }

        /// <inheritdoc />
        public abstract Expression GetExpression(MemberExpression member, ConstantExpression constant1, ConstantExpression constant2);
        public abstract Expression GetExpression(Expression member, ConstantExpression constant1, ConstantExpression constant2);

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return (Name != null ? Name.GetHashCode() : 0);
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return obj.GetType() == GetType() && Equals((ConditionBase)obj);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return Name.Trim();
        }

        public bool Equals(ICondition other)
        {
            return string.Equals(Name, other.Name);
        }
    }
}