using System;

public class TheHeiganDance
{
    private static void Main()
    {
        var playerRow = 7;
        var playerCol = 7;
        var playerLife = 18500;
        var heiganLife = 3000000d;
        var playerDoneDamage = double.Parse(Console.ReadLine());
        var lastSpell = string.Empty;
        var cloudFromLastTurn = false;
        while (playerLife > 0
               && heiganLife > 0)
        {
            var matrix = new bool[15, 15];
            heiganLife -= playerDoneDamage;
            if (cloudFromLastTurn)
            {
                playerLife -= 3500;
                cloudFromLastTurn = false;
            }

            if (heiganLife <= 0
                || playerLife <= 0)
            {
                break;
            }

            var tokens = Console.ReadLine().Split(' ');
            var spell = tokens[0];
            var spellRow = int.Parse(tokens[1]);
            var spellCol = int.Parse(tokens[2]);
            for (var row = spellRow - 1; row <= (spellRow + 1) && row < matrix.GetLength(0); row++)
            {
                if (row < 0)
                {
                    continue;
                }

                for (var col = spellCol - 1; col <= (spellCol + 1) && col < matrix.GetLength(1); col++)
                {
                    if (col < 0)
                    {
                        continue;
                    }

                    matrix[row, col] = true;
                }
            }

            if (matrix[playerRow, playerCol])
            {
                if ((playerRow - 1) >= 0
                    && matrix[playerRow - 1, playerCol] == false)
                {
                    playerRow--;
                }
                else if ((playerCol + 1) < matrix.GetLength(1)
                         && matrix[playerRow, playerCol + 1] == false)
                {
                    playerCol++;
                }
                else if ((playerRow + 1) < matrix.GetLength(0)
                         && matrix[playerRow + 1, playerCol] == false)
                {
                    playerRow++;
                }
                else if ((playerCol - 1) >= 0
                         && matrix[playerRow, playerCol - 1] == false)
                {
                    playerCol--;
                }
            }

            if (matrix[playerRow, playerCol])
            {
                if (spell.Equals("Cloud"))
                {
                    playerLife -= 3500;
                    cloudFromLastTurn = true;
                    lastSpell = string.Concat("Plague ", spell);
                }
                else if (spell.Equals("Eruption"))
                {
                    playerLife -= 6000;
                    lastSpell = spell;
                }
            }
        }

        Console.WriteLine(heiganLife <= 0 ? "Heigan: Defeated!" : $"Heigan: {heiganLife:f2}");
        Console.WriteLine(playerLife <= 0 ? $"Player: Killed by {lastSpell}" : $"Player: {playerLife}");
        Console.WriteLine($"Final position: {playerRow}, {playerCol}");
    }
}