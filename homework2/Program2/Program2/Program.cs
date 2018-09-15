using System;

namespace Program2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入数组元素（以空格隔开）：");
            
            char[] s = new char[] { ' ' };
            string[] arr = Console.ReadLine().Split(s);
            int[] arry = new int[arr.Length];
            arry = Array.ConvertAll<string, int>(arr, m => int.Parse(m));

            int max = arry[0];
            for (int n = 1; n < arr.Length; n++)
            {
                if (max < arry[n])
                    max = arry[n];

            }
            Console.WriteLine("最大值是" + max);
            int min = arry[0];

            for (int a = 1; a < arr.Length; a++)
            {
                if (min > arry[a])
                    min = arry[a];
            }
            Console.WriteLine("最小值是" + min);
            int all = 0;
            for (int h = 0; h < arr.Length; h++)
            {
                all = all + arry[h];
            }
            double average = (double)all / arr.Length;
            Console.WriteLine("平均值是" + average);
            Console.WriteLine("数组所有元素的和为" + all);

            Console.ReadKey(false);

        }
    }
}
