using System;
using System.Linq;

    class MostFrequentNumber
    {
        static void Main()
        {
            var array = Console.ReadLine()
                .Split(' ')
                .Select(ushort.Parse)
                .ToArray();
            var arrayElementIndicate = new bool[array.Length];

            for (int i = 0; i < arrayElementIndicate.Length; i++)
            {
                arrayElementIndicate[i] = true;
            }

            int bestIndex = 0, 
                bestCount = 1;

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (!arrayElementIndicate[i])
                {
                    continue;
                }

                int currentCount = 1;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if(!arrayElementIndicate[i])
                    {
                        continue;
                    }

                    if(array[i].Equals(array[j]))
                    {
                        ++currentCount;
                        arrayElementIndicate[j] = false;
                    }
                }

                if(currentCount > bestCount)
                {
                    bestCount = currentCount;
                    bestIndex = i;
                }
            }

            Console.WriteLine(array[bestIndex]);
        }
    }