class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter the foot for Conversion:");
        int foot = int.Parse(Console.ReadLine());
        double centimeter = Math.Round(ConvertToCentimeter(foot),2,MidpointRounding.AwayFromZero);
        Console.WriteLine(centimeter);

        
    }
    public static double ConvertToCentimeter(int foot)
    {
        return foot*30.48;
    }
}