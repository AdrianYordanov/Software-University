using System;
using System.Collections.Generic;

public class DragonArmy
{
    public static void Main()
    {
        var n = int.Parse(Console.ReadLine());
        var dragonTypes = new Dictionary<string, SortedDictionary<string, int[]>>();
        for (var i = 0; i < n; ++i)
        {
            var tokens = Console.ReadLine()
                .Split(' ');
            var type = tokens[0];
            var name = tokens[1];
            if (!int.TryParse(tokens[2], out int damage))
            {
                damage = 45;
            }

            if (!int.TryParse(tokens[3], out int health))
            {
                health = 250;
            }

            if (!int.TryParse(tokens[4], out int armor))
            {
                armor = 10;
            }

            if (dragonTypes.ContainsKey(type))
            {
                if (dragonTypes[type]
                    .ContainsKey(name))
                {
                    dragonTypes[type][name][0] = damage;
                    dragonTypes[type][name][1] = health;
                    dragonTypes[type][name][2] = armor;
                }
                else
                {
                    dragonTypes[type]
                        .Add(
                            name, 
                            new[] { damage, health, armor });
                }
            }
            else
            {
                var dragonNames = new SortedDictionary<string, int[]>
                {
                    {
                        name, new[]
                        {
                            damage,
                            health,
                            armor
                        }
                    }
                };
                dragonTypes.Add(type, dragonNames);
            }
        }

        foreach (var pair in dragonTypes)
        {
            var type = pair.Key;
            var dragons = pair.Value;
            var avarageDamage = 0D;
            var avarageHealth = 0D;
            var avarageArmor = 0D;
            foreach (var dragonInfo in dragons.Values)
            {
                avarageDamage += dragonInfo[0];
                avarageHealth += dragonInfo[1];
                avarageArmor += dragonInfo[2];
            }

            avarageDamage /= dragons.Count;
            avarageHealth /= dragons.Count;
            avarageArmor /= dragons.Count;
            Console.WriteLine("{0}::({1:f2}/{2:f2}/{3:f2})", type, avarageDamage, avarageHealth, avarageArmor);
            foreach (var nestedPair in dragons)
            {
                var name = nestedPair.Key;
                var info = nestedPair.Value;
                Console.WriteLine($"-{name} -> damage: {info[0]}, health: {info[1]}, armor: {info[2]}");
            }
        }
    }
}