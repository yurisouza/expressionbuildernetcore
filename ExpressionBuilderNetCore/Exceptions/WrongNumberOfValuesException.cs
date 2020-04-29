﻿using ExpressionBuilderNetCore.Interfaces;
using System;

namespace ExpressionBuilderNetCore.Exceptions
{
    /// <summary>
    /// Represents an attempt to use an operation providing the wrong number of values.
    /// </summary>
    [Serializable]
    public class WrongNumberOfValuesException : Exception
    {
        /// <summary>
        /// Gets the <see cref="Operation" /> attempted to be used.
        /// </summary>
        public ICondition Operation { get; private set; }

        /// <summary>
        /// Gets a message that describes the current exception.
        /// </summary>
        public override string Message
        {
            get
            {
                return string.Format("The operation '{0}' admits exactly '{1}' values (not more neither less than this).", Operation.Name, Operation.NumberOfValues);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WrongNumberOfValuesException" /> class.
        /// </summary>
        /// <param name="operation">Operation used.</param>
        public WrongNumberOfValuesException(ICondition operation)
        {
            Operation = operation;
        }
    }
}