// class Program
// {
//     public static void Main()
//     {
//         int[] sortArr1 = {1,2,3,4};
//         int[] sortArr2 = {5,6,7,8};
//         int[] arr = SortArr(sortArr1,sortArr2);
//         foreach(int i in arr)
//         {
//             Console.WriteLine(i);
//         }

//     }
//     public static T[] SortArr<T>(T[] a,T[] b) where T : IComparable<T>
//     {
//         T[] result = new T[a.Length+b.Length];
//         int i=0;
//         int j=0;
//         int k=0;
//         while (i < a.Length && j < b.Length)
//         {
//             if (a[i].CompareTo(b[j]) <= 0)
//             {
//                 result[k]=a[i];
//                 i++;
//             }
//             else
//             {
//                 result[k]=b[j];
//                 j++;
//             }
//             k++;
//         }
//         while (i < a.Length)
//         {
//             result[k]=a[i];
//             i++;
//             k++;
//         }
//         while (j < b.Length)
//         {
//             result[k]=b[j];
//             j++;
//             k++;
//         }
//         return result;
//     }
    
// }

