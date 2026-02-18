public class ShoppingCart<T> where T : Product
{
    private Dictionary<T, int> _cartitems = new Dictionary<T, int>();
    public void AddToCart(T product, int quantity)
    {
        if (_cartitems.ContainsKey(product))
        {
            _cartitems[product] += quantity;
            
        }
        else
        {
            _cartitems.Add(product, quantity);
        }
        Console.WriteLine($"{quantity}x {product.Name} added to cart.");
    }
    public double CalculateTotal(Func<T, double, double> discountCalculator = null)
    {
        double total = 0;
        foreach (var item in _cartitems)
        {
            double price = item.Key.Price * item.Value;
            if(discountCalculator != null)
            {
                price = discountCalculator(item.Key, price);
            }
            total += price;
        }
        return total;
    }
    public List<T> GetTopExpensiveItems(int n)
    {
        // TODO: Use LINQ OrderByDescending and Take
        var top = _cartitems.Keys.OrderByDescending(k => k.Price).Take(n).ToList();
        return top;
    }


}