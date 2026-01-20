using System.Text;

class Question3
{
    public static void Main()
    {
        string input = Console.ReadLine();
        string final = input.Trim();
        StringBuilder string1 = new StringBuilder();
        for(int i = 0; i < input.Length - 1; i++)
        {
            if (input[i] == input[i + 1])
            {
                continue;
            }
            string1.Append(input[i]);
        }
        int len = input.Length;
        string1.Append(input[len-1]);
        string[] intputstring = string1.ToString().Split(" ",StringSplitOptions.RemoveEmptyEntries);

        for(int i = 0; i < intputstring.Length; i++)
        {
            if (intputstring[i].Length > 0)
            {
                string word = char.ToUpper(intputstring[i][0])+intputstring[i].Substring(1).ToLower();
                intputstring[i]=word;
            }
        }

        final = string.Join(" ",intputstring);
        Console.WriteLine(final);

    }
}