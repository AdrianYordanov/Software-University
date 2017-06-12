using System;

class MelrahShake
{
    static void Main()
    {
        var text = Console.ReadLine();
        var pattern = Console.ReadLine();

        while (pattern.Length > 0)
        {
            var leftMost = text.IndexOf(pattern);

            if (leftMost != -1)
            {
                if (leftMost + pattern.Length > text.Length - 1)
                {
                    break;
                }

                var rightMost = text.LastIndexOf(pattern, leftMost + pattern.Length);

                if (rightMost != -1)
                {
                    text = text.Remove(leftMost, pattern.Length);
                    rightMost = text.LastIndexOf(pattern);
                    text = text.Remove(rightMost, pattern.Length);
                    pattern = pattern.Remove(pattern.Length / 2, 1);
                    Console.WriteLine("Shaked it.");
                }
                else
                {
                    break;
                }
            }
            else
            {
                break;
            }
        }

        Console.WriteLine("No shake.");
        Console.WriteLine(text);
    }
}