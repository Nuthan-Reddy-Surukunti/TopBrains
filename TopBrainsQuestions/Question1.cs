using System.Text;

class Question1
{
    public static void Main()
    {
        string input1 = Console.ReadLine();
        string input2 = Console.ReadLine().ToLower();
        string vowels = "aeiou";
        StringBuilder word1 = new StringBuilder();
        for(int i = 0; i < input1.Length; i++)
        {
            if (!vowels.Contains(input1[i])&&input2.Contains(input1[i]))
            {
                continue;
            }
            
            word1.Append(input1[i]);
        }
        for (int i = 0; i < word1.Length-1; i++)
        {
            if (word1[i] == word1[i + 1])
            {
                word1.Remove(i,1);
                i--;
            }
        }
        string o1= word1.ToString();
        Console.WriteLine(o1);

    }
}