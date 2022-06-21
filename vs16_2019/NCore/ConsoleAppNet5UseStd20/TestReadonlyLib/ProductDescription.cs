using System;
using System.Collections.Generic;
using System.Text;

namespace TestReadonlyLib {
    /// <summary>
    /// ProductDescription
    /// </summary>
    /// <remarks>https://docs.microsoft.com/zh-cn/dotnet/csharp/language-reference/builtin-types/nullable-reference-types</remarks>
    public class ProductDescription {
        private string shortDescription;
        private string? detailedDescription;

        public ProductDescription() // Warning! shortDescription not initialized.
        {
        }

        public ProductDescription(string productDescription) =>
            this.shortDescription = productDescription;

        public void SetDescriptions(string productDescription, string? details = null) {
            shortDescription = productDescription;
            detailedDescription = details;
        }

        public string GetDescription() {
            if (detailedDescription.Length == 0) // Warning! dereference possible null
            {
                return shortDescription;
            } else {
                return $"{shortDescription}\n{detailedDescription}";
            }
        }

        public string FullDescription() {
            if (detailedDescription == null) {
                return shortDescription;
            } else if (detailedDescription.Length > 0) // OK, detailedDescription can't be null.
              {
                return $"{shortDescription}\n{detailedDescription}";
            }
            return shortDescription;
        }

        public override string ToString() => $"({shortDescription}, {detailedDescription})";

    }
}
