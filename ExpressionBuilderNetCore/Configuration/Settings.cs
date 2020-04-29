using System.Collections.Generic;

namespace ExpressionBuilderNetCore.Configuration
{
    public class Settings
    {
        public Settings()
        {
            SupportedTypes = new List<SupportedType>();
        }

        public List<SupportedType> SupportedTypes { get; set; }
    }
}