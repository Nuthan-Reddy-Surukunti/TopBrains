class Program
{
    public static string[] CustomDistinct(string[] s)
    {
        HashSet<int> input = new HashSet<int>();
        List<string> strings = new List<string>();
        foreach(string i in s)
        {
            string[] parts = i.Split(":");
            if (!input.Contains(int.Parse(parts[0])))
            {
                input.Add(int.Parse(parts[0]));
                strings.Add(parts[1]);
            }
        }
        return strings.ToArray();
    }
    public static void Main()
    {
         string[] input =
        {
            "1:Nuthan",
            "2:Reddy",
            "1:Surukunti",
            "3:Ram",
            "2:Sham"
        };

        string[] output = CustomDistinct(input);

        foreach (var name in output)
        {
            Console.WriteLine(name);
        }
    }
}