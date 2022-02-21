using System;
using System.Collections.Generic;
using System.Numerics;

namespace BOJ_1837
{
    internal static class MainApp
    {
        private static void Main(string[] args)
        {
            var line = Console.ReadLine();
            var sp = line.Split(' ');

            var p = BigInteger.Parse(sp[0]);
            var k = int.Parse(sp[1]);

            FindPrimesUnder(k);

            foreach (var d in primes_)
            {
                if (0 == p % d)
                {
                    Console.WriteLine($"BAD {d}");
                    return;
                }
            }

            Console.WriteLine("GOOD");
        }

        private static readonly List<bool> sieve_ = new List<bool>();
        private static readonly List<int> primes_ = new List<int>();

        private static void FindPrimesUnder(int k)
        {
            InitializeSieve(k);

            for (int i = 2; i < k; i++)
            {
                if (sieve_[i])
                {
                    primes_.Add(i);

                    var j = i + i;
                    while (j < k)
                    {
                        sieve_[j] = false;
                        j += i;
                    }
                }
            }
        }

        private static void InitializeSieve(int k)
        {
            for (int i = 0; i < k; i++)
            {
                sieve_.Add(true);
            }
            sieve_[0] = false;
            sieve_[1] = false;
        }
    }
}