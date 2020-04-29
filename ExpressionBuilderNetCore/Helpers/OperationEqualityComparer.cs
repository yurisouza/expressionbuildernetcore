using ExpressionBuilderNetCore.Interfaces;
using System;
using System.Collections.Generic;

namespace ExpressionBuilderNetCore.Helpers
{
    internal class OperationEqualityComparer : IEqualityComparer<ICondition>
    {
        public bool Equals(ICondition x, ICondition y)
        {
            return string.Compare(x.Name, y.Name, StringComparison.InvariantCultureIgnoreCase) == 0
                    && x.Active && y.Active;
        }

        public int GetHashCode(ICondition obj)
        {
            return obj.Name.GetHashCode() ^ obj.Active.GetHashCode();
        }
    }
}