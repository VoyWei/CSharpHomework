using System;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("请输入一个数：");
            int num = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("该数的素数因子为：");
            for (int i = 2; i < num; i++)
            {
                while (num != i)
                {
                    if (num % i == 0)
                    {
                        Console.Write(i + " ");
                        num /= i;
                    }
                    else
                    {
                        break;
                    }
                }
            }

            Console.WriteLine(num);
        }
    }
}
