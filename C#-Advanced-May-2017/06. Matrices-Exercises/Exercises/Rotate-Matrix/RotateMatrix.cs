using System;
using System.Collections.Generic;
using System.Linq;

public class RotateMatrix
{
    private static void Main()
    {
        var number = int.Parse(Console.ReadLine().Split(new[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries)[1]);
        var strings = new List<string>();
        string input;
        while (number >= 360)
        {
            number -= 360;
        }

        while ((input = Console.ReadLine()) != "END")
        {
            strings.Add(input);
        }

        switch (number)
        {
            case 0:
                {
                    for (var stringIndex = 0; stringIndex < strings.Count; stringIndex++)
                    {
                        Console.WriteLine(strings[stringIndex]);
                    }

                    break;
                }

            case 90:
                {
                    strings.Reverse();
                    var maxLength = strings.Max(x => x.Length);
                    for (var charIndex = 0; charIndex < maxLength; charIndex++)
                    {
                        for (var stringIndex = 0; stringIndex < strings.Count; ++stringIndex)
                        {
                            if (charIndex < strings[stringIndex].Length)
                            {
                                Console.Write(strings[stringIndex][charIndex]);
                            }
                            else
                            {
                                Console.Write(' ');
                            }
                        }

                        Console.WriteLine();
                    }

                    break;
                }

            case 180:
                {
                    strings.Reverse();
                    var maxLength = strings.Max(x => x.Length);
                    for (var stringIndex = 0; stringIndex < strings.Count; stringIndex++)
                    {
                        var reversedString = new string(strings[stringIndex].Reverse().ToArray());
                        Console.WriteLine(reversedString.PadLeft(maxLength));
                    }

                    break;
                }

            case 270:
                {
                    var maxLength = strings.Max(x => x.Length);
                    for (var charIndex = maxLength - 1; charIndex >= 0; charIndex--)
                    {
                        for (var stringIndex = 0; stringIndex < strings.Count; ++stringIndex)
                        {
                            if (charIndex < strings[stringIndex].Length)
                            {
                                Console.Write(strings[stringIndex][charIndex]);
                            }
                            else
                            {
                                Console.Write(' ');
                            }
                        }

                        Console.WriteLine();
                    }

                    break;
                }
        }
    }
}