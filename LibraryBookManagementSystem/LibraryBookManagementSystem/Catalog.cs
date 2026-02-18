public class Catalog<T> where T : Book
{
    private List<T> _items = new List<T>();
    private HashSet<string> _isbnSet = new HashSet<string>();
    private SortedDictionary<string, List<T>> _genreIndex = new SortedDictionary<string, List<T>>();

    public bool AddItem(T item)
    {
        if (!_isbnSet.Add(item.ISBN))
        {
            Console.WriteLine("Duplicate is there");
            return false;
        }
        _items.Add(item);
        if (!_genreIndex.ContainsKey(item.Genre))
        {
            _genreIndex[item.Genre] = new List<T>();
        }
        _genreIndex[item.Genre].Add(item);
        Console.WriteLine($"Book {item.Title} has been added to the list and dictionary.");
        return true;
    }
    public List<T> this[string genre]
    {
        get
        {
            return _genreIndex.ContainsKey(genre) ? _genreIndex[genre] : new List<T>();
        }
    }
    public IEnumerable<T> FindBooks(Func<T, bool> predicate)
    {
        return _items.Where(predicate);
    }
}