using System;

class SieveOfEratosthense
{
    static void Main()
    {
        long total = long.Parse(Console.ReadLine());
        bool[] notPrime = new bool[total + 1];
        notPrime[0] = true;
        notPrime[1] = true;

        for (long i = 0; i < notPrime.Length; i++)
        {
            if (!notPrime[i])
            {
                Console.Write(i + " ");

                for (long j = i * 2; j < notPrime.Length; j += i)
                {
                    notPrime[j] = true;
                }
            }
        }
    }
}
