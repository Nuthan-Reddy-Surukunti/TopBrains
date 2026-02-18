using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlexibleInventorySystem_Practice.Models;

namespace FlexibleInventorySystem_Practice.Utilities
{
    
        /// <summary>
        /// TODO: Implement validation helper class
        /// </summary>
        public static class ProductValidator
        {
            /// <summary>
            /// TODO: Validate product data
            /// Check:
            /// - ID not null/empty
            /// - Name not null/empty
            /// - Price > 0
            /// - Quantity >= 0
            /// </summary>
            public static bool ValidateProduct(Product product, out string errorMessage)
            {
                // TODO: Implement validation
                if(product.Id!=null && product.Id!=string.Empty && product.Name!=null && product.Name!=string.Empty && product.Price>0 && product.Quantity >= 0)
                {
                    errorMessage = null;
                    return true;
                }
                errorMessage = "Invalid product";
                return false;
            }

            /// <summary>
            /// TODO: Validate electronic product specific rules
            /// </summary>
            public static bool ValidateElectronicProduct(ElectronicProduct product, out string errorMessage)
            {
                // TODO: Implement electronic validation
                if(product.Brand!=null && product.Brand!=string.Empty && product.WarrantyMonths>=0 && product.Voltage != null && product.Voltage!=string.Empty)
                {
                    errorMessage=null;
                    return true;
                }
                errorMessage = "Invalid Electronic Product";
                return false;
            }

            /// <summary>
            /// TODO: Validate grocery product specific rules
            /// </summary>
            public static bool ValidateGroceryProduct(GroceryProduct product, out string errorMessage)
            {
                // TODO: Implement grocery validation
                if(product.ExpiryDate>=DateTime.Now && product.Weight > 0)
                {
                    errorMessage=null;
                    return true;
                }
                errorMessage = "Invalid Grocery Product";
                return false;
            }

            /// <summary>
            /// TODO: Validate clothing product specific rules
            /// </summary>
            public static bool ValidateClothingProduct(ClothingProduct product, out string errorMessage)
            {
                // TODO: Implement clothing validation
                if(product.Size!=null && product.Size!=string.Empty && product.Color!=null && product.Color!=string.Empty && product.Material!=null && product.Material!=string.Empty && product.Gender!=null && product.Gender!=string.Empty && product.Season!=null && product.Season!=string.Empty)
                {
                    errorMessage=null;
                    return true;
                }
                errorMessage = "Invalid Clothing Product";
                return false;
            }
        }
}
