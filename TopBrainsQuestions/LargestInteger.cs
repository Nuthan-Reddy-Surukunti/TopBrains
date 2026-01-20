class Program
{
    public static void Main()
    {
        int num1=Convert.ToInt32(Console.ReadLine());
        int num2=Convert.ToInt32(Console.ReadLine());
        int num3=Convert.ToInt32(Console.ReadLine());
        int LargInt = LargestInt(num1,num2,num3);
        Console.WriteLine(LargInt);
    }
    public static int LargestInt(int a,int b,int c)
    {
        if (a >= b && a>=c)
        {
            return a;
        }
        else if (b >= c)
        {
            return b;
        }
        return c;
    }
}