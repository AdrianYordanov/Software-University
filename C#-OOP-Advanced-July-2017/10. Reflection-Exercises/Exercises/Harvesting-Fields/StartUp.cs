using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class StartUp
{
    private static void Main()
    {
        var classType = typeof(HarvestingFields);
        while (true)
        {
            var input = Console.ReadLine();
            if (input.ToLower() == "harvest")
            {
                break;
            }

            IEnumerable<FieldInfo> fields = null;
            switch (input)
            {
                case "private":
                    fields = classType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                       .Where(f => f.IsPrivate);
                    break;
                case "protected":
                    fields = classType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                       .Where(f => f.IsFamily);
                    break;
                case "public":
                    fields = classType.GetFields(BindingFlags.Public | BindingFlags.Instance);
                    break;
                case "all":
                    fields = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                       .Where(f => f.IsPublic || f.IsPrivate || f.IsFamily);
                    break;
            }

            if (fields != null)
            {
                var fieldsAsListString = fields.ToList()
                   .Select(f => $"{f.Attributes.ToString() .ToLower()} {f.FieldType.Name} {f.Name}")
                   .ToList();
                var result = fieldsAsListString.Select(str => str.Replace("family", "protected"));
                Console.WriteLine(string.Join(Environment.NewLine, result));
            }
        }
    }
}