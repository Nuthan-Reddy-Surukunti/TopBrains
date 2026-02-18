using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexibleInventorySystem_Practice.Models
{
    
        /// <summary>
        /// TODO: Implement clothing product class
        /// </summary>
        public class ClothingProduct : Product
        {
            // TODO: Add these properties
            // - Size (string)
            public string Size { get; set; }
            // - Color (string)
            public string Color { get; set; }
            // - Material (string)
            public string Material { get; set; }
            // - Gender (string) - "Men", "Women", "Unisex"
            public string Gender { get; set; }
            // - Season (string) - "Summer", "Winter", "All-season"
            public string Season { get; set; }

            /// <summary>
            /// TODO: Override GetProductDetails for clothing items
            /// </summary>
            public override string GetProductDetails()
            {
                // TODO: Return formatted string with size, color, material
                return $"{Name} {Price} {Size} {Color} {Material} {Gender} {Season}";
            }

            /// <summary>
            /// TODO: Check if size is available
            /// Valid sizes: XS, S, M, L, XL, XXL
            /// </summary>
            public bool IsValidSize()
            {
                // TODO: Validate size against allowed values
                var validSizes = new List<string> { "XS", "S", "M", "L", "XL", "XXL" };
                return validSizes.Contains(Size);
            }

            /// <summary>
            /// TODO: Override CalculateValue to apply seasonal discount
            /// Apply 15% discount for off-season items
            /// </summary>
            public override decimal CalculateValue()
            {
                // TODO: Apply seasonal discount logic
                var discount = 0m;
                if (Season != "All-season")
                {
                    discount = 0.15m; // 15% discount for off-season items
                }
                return Price * Quantity * (1 - discount);
            }
        }   
}