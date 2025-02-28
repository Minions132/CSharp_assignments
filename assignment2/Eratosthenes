using System;
using System.Collections.Generic;

namespace Eratosthenes{
    class Algorithm{
        static List<int> SieveOfEratosthenes(int n)
        {
            bool[] isPrime = new bool[n + 1];
            Array.Fill(isPrime, true);
            isPrime[0] = isPrime[1] = false;
            for (int i = 2; i * i <= n; i++)
            {
                if (isPrime[i])
                {
                    for (int j = i * i; j <= n; j += i)
                    {
                        isPrime[j] = false;
                    }
                }
            }
            List<int> primes = new List<int>();
            for (int i = 2; i <= n; i++)
            {
                if (isPrime[i])
                {
                    primes.Add(i);
                }
            }            
            return primes;
        }

        static void Main(string[] args){
            int n = 100;
            var primes = SieveOfEratosthenes(n);
            Console.WriteLine($"找到的素数有: {string.Join(", ", primes)}");
        }
    }
}