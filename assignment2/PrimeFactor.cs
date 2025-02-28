using System;

namespace PrimeFactor
{
    class PrimeFactor
    {
        static void Main(string[] args)
        {
            Console.Write("请输入一个正整数：");
            if (long.TryParse(Console.ReadLine(), out long number))
            {
                Console.Write($"{number} 的素数因子为：");
                GetPrimeFactors(number);
            }
            else
            {
                Console.WriteLine("输入无效，请输入一个有效的正整数。");
            }
        }

        static void GetPrimeFactors(long number)
        {
            for (long i = 2; i <= number; i++)
            {
                while (number % i == 0)
                {
                    Console.Write($"{i} ");
                    number /= i;
                }
            }
            Console.WriteLine();
        }
    }
}
