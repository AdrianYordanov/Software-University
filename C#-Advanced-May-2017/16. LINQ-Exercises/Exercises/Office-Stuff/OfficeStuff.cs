using System;
using System.Collections.Generic;
using System.Linq;

class OfficeStuff
{
    static void Main()
    {
        var companyProductAmount = new SortedDictionary<string, Dictionary<string, int>>();
        var n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            var input = Console.ReadLine().Split(new string[] { " - ", "|" }, StringSplitOptions.RemoveEmptyEntries);
            var company = input[0];
            var product = input[2];
            var amount = int.Parse(input[1]);

            if (!companyProductAmount.ContainsKey(company))
            {
                companyProductAmount[company] = new Dictionary<string, int>();
            }

            if (!companyProductAmount[company].ContainsKey(product))
            {
                companyProductAmount[company][product] = 0;
            }

            companyProductAmount[company][product] += amount;
        }

        foreach (var company in companyProductAmount)
        {
            Console.WriteLine($"{company.Key}: {string.Join(", ", company.Value.Select(s => s.Key + "-" + s.Value))}");
        }
    }
}