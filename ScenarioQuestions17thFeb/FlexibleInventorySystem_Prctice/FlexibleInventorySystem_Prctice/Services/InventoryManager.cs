using FlexibleInventorySystem_Practice.Interfaces;
using FlexibleInventorySystem_Practice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlexibleInventorySystem_Practice.Services
{  
    public class InventoryManager : IInventoryOperations, IReportGenerator
    {
        private  List<Product> _products;
        private readonly object _lockObject = new object();

        public InventoryManager()
        {
            _products = new List<Product>();
        }

        public bool AddProduct(Product product)
        {
            var check = _products.Any(p => p.Id == product.Id);
            if (check)
            {
                return false; 
            }
            _products.Add(product);
            return true;
        }

        public Product FindProduct(string productId)
        {
            return _products.FirstOrDefault(i=>i.Id==productId);
            
        }

        public string GenerateCategorySummary()
        {
            var summary = new StringBuilder();
            var categories = _products.GroupBy(p => p.Category);
            foreach (var category in categories)
            {
                summary.AppendLine($"Category: {category.Key}, Count: {category.Count()}, Total Value: {category.Sum(p => p.CalculateValue())}");
            }
            return summary.ToString();
        }

        public string GenerateExpiryReport(int daysThreshold)
        {
            StringBuilder result = new StringBuilder();
            var groceryProducts = _products.OfType<GroceryProduct>().Where(i=>(i.ExpiryDate-DateTime.Now).Days<=daysThreshold);
            foreach(var i in groceryProducts)
            {
                result.AppendLine($"{i.Name} {(i.ExpiryDate-DateTime.Now).Days}");
            }
            return result.ToString();
        }

        public string GenerateInventoryReport()
        {
            StringBuilder result = new StringBuilder();
            foreach(var item in _products)
            {
                result.AppendLine($"{item.Id} {item.Name} {item.Category} - {item.Quantity} {item.CalculateValue()}");
            }
            return result.ToString();
            
        }

        public string GenerateValueReport()
        {
            StringBuilder result = new StringBuilder();
            var mostValuableProduct = _products.OrderByDescending(p=>p.Price).FirstOrDefault().ToString();
            result.AppendLine("Most Valualble Product"+mostValuableProduct);
            var leastValuableProduct = _products.OrderBy(p=>p.Price).FirstOrDefault().ToString();
            result.AppendLine("Least: "+leastValuableProduct);
            var averagePrice = _products.Average(p=>p.Price);
            result.AppendLine("Average Price: "+averagePrice.ToString());
            var medianPrice = _products.OrderBy(p=>p.Price).Skip(_products.Count/2).FirstOrDefault().ToString();
            result.AppendLine("Median Price: "+medianPrice);
            var aboveAveragePrice = _products.Where(p=>p.Price>averagePrice);
            result.AppendLine("aboveAveragePrice: ");
            foreach(var item in aboveAveragePrice)
            {
                result.AppendLine($"{item.Name} Price: {item.Price}");
            }
            return result.ToString();
        }

        public List<Product> GetLowStockProducts(int threshold)
        {
            return _products.Where(i=>i.Quantity<=threshold).ToList();
        }

        public List<Product> GetProductsByCategory(string category)
        {
            return _products
            .Where(i=>i.Category.Equals(category,StringComparison.OrdinalIgnoreCase))
            .ToList();
            
        }

        public decimal GetTotalInventoryValue()
        {
            return _products.Sum(t=>t.CalculateValue());
        }

        public bool RemoveProduct(string productId)
        {
            var product = _products.FirstOrDefault(i=>i.Id==productId);
            if (product != null)
            {
                _products.Remove(product);
                return true;
            }
            return false;
            
        }

        // Implement all interface methods here

        // Additional methods for bonus features
        public IEnumerable<Product> SearchProducts(Func<Product, bool> predicate)
        {
            return _products.Where(predicate);
        }

        public bool UpdateQuantity(string productId, int newQuantity)
        {
            if (newQuantity < 0) return false;
            var check = _products.FirstOrDefault(i=>i.Id==productId);
            if(check==null) return false;
            check.Quantity=newQuantity;
            return true;
        }

        
    }    
}
