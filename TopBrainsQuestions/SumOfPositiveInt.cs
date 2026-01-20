public class Program
{
    public static void Main()
    {
        Console.WriteLine("Enter the total count of numbers:");
        int numTotal=Convert.ToInt32(Console.ReadLine());
        int[] numbers = new int[numTotal];
        for(int i = 0; i < numTotal; i++)
        {
            Console.Write($"Enter number {i+1}: ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }
        Console.WriteLine($"Sum of total positve numbers: {SumPositiveUntilZero(numbers)}");
    }
    public static int SumPositiveUntilZero(int[] nums)
    {
        int sum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
            {
                break;
            }

            if (nums[i] < 0)
            {
                continue;
            }

            sum += nums[i];
        }

        return sum;
    }

}