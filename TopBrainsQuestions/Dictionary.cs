class Dictionary
{
    public static void Main()
    {
        List<int> Ids = new List<int>{1,4,5};
        Dictionary<int,int> salaryDic = new Dictionary<int, int>{{1,20000},{4,40000},{5,15000}};
        int totalSalary=0;
        int i=0;
        foreach(KeyValuePair<int,int> salary in salaryDic)
        {
            if (Ids[i]==salary.Key)
            {
                totalSalary+=salary.Value;
                i++;
            }
        }
        Console.WriteLine(totalSalary);
    }
}