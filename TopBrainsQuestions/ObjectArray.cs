class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter total number to objects need to be stored:");
        int total = Convert.ToInt32(Console.ReadLine());
        object[] arr = new object[total];
        int sum=0;
        for(int i = 0; i < total; i++)
        {
            Console.WriteLine($"Enter object{i+1}:");
            arr[i]=Console.ReadLine();
            if(int.TryParse((string)arr[i],out int number))
            {
                sum+=number;
            }
        }
        Console.WriteLine($"Total sum of enter Numbers: {sum}");
    }
}