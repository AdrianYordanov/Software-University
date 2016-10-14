using System;
using System.Linq;
using System.Numerics;

class SoftuniCofeeOrders
{
    static void Main()
    {
        long n = long.Parse(Console.ReadLine());
        decimal total = 0;

        for (int i = 0; i < n; i++)
        {
            decimal pricePerCapsule = decimal.Parse(Console.ReadLine());
            string date = Console.ReadLine();
            uint capsuleCount = uint.Parse(Console.ReadLine());

            int mounth = int.Parse(date.Split('/')[1]);
            int year = int.Parse(date.Split('/')[2]);
            int totalDaysInCurrentMounth = DateTime.DaysInMonth(year, mounth);
            decimal sum = totalDaysInCurrentMounth * pricePerCapsule * capsuleCount;

            Console.WriteLine("The price for the coffee is: ${0:F2}", sum);
            total += sum;
        }

        Console.WriteLine("Total: ${0:F2}", total);
    }
}