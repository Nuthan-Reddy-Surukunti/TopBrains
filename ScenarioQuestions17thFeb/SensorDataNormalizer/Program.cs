interface IValueParser
{
    float[]? ParsingNumericForm(string s);
}
interface IValueRounding
{
    float[] RoundingNumericValues(float[] s);
}

class Program :IValueParser,IValueRounding
{
    public static void Main()
    {
        string? input = Console.ReadLine();
        var parsingNumbers = ParsingNumericForm(input);
        var roundedNumbers = RoundingNumericValues(parsingNumbers);
        Console.WriteLine(string.Join(", ",roundedNumbers));

    }
    public static float[] ParsingNumericForm(string s)
    {
        string[] parts = s.Split(",",StringSplitOptions.RemoveEmptyEntries);
        float[] result = new float[parts.Length];
        int j=0;
        foreach(var i in parts)
        {
            if(float.TryParse(i.Trim(),out float number))
            {
                result[j]=number;
                j++;
            }
        }
        return result;
    }
    public static float[] RoundingNumericValues(float[] input)
    {
        float[] result = new float[input.Length];
        int j=0;
        foreach(var i in input)
        {
            result[j]=(float)Math.Round(i,2,MidpointRounding.AwayFromZero);
            j++;
        }
        return result;
    }
}
