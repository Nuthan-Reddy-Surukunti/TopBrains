class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter Number1: ");
        int Number1 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter Number2: ");
        int Number2 = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"GCD of {Number1} and {Number2} is {GCD(Number1,Number2)}");
    }
    public static int GCD(int a,int b)
    {
        if (b == 0)
        {
            return a;
        }
        return GCD(b,a%b);
    }
}