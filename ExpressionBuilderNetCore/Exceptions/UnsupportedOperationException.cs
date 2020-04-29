﻿using ExpressionBuilderNetCore.Interfaces;
using System;

namespace ExpressionBuilderNetCore.Exceptions
{
    /// <summary>
    /// Represents an attempt to use an operation not currently supported by a type.
    /// </summary>
    [Serializable]
    public class UnsupportedOperationException : Exception
    {
        /// <summary>
        /// Gets the <see cref="Operation" /> attempted to be used.
        /// </summary>
        public ICondition Operation { get; private set; }

        /// <summary>
        /// Gets name of the type.
        /// </summary>
        public string TypeName { get; private set; }

        /// <summary>
        /// Gets a message that describes the current exception.
        /// </summary>
        public override string Message
        {
            get
            {
                return string.Format("The type '{0}' does not have support for the operation '{1}'.", TypeName, Operation);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UnsupportedOperationException" /> class.
        /// </summary>
        /// <param name="operation">Operation used.</param>
        /// <param name="typeName">Name of the type.</param>
        public UnsupportedOperationException(ICondition operation, String typeName)
        {
            Operation = operation;
            TypeName = typeName;
        }
    }
}