using System;
using System.Collections.Generic;
using System.Linq;

class RotateMatrix
{
    static void Main()
    {
        var number = int.Parse(Console.ReadLine().Split(new char[] { '(', ')' }, StringSplitOptions.RemoveEmptyEntries)[1]);
        var strings = new List<string>();
        var input = string.Empty;

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
                    for (int stringIndex = 0; stringIndex < strings.Count; stringIndex++)
                    {
                        Console.WriteLine(strings[stringIndex]);
                    }
                    break;
                }
            case 90:
                {
                    strings.Reverse();
                    var maxLength = strings.Max(x => x.Length);

                    for (int charIndex = 0; charIndex < maxLength; charIndex++)
                    {
                        for (int stringIndex = 0; stringIndex < strings.Count; ++stringIndex)
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

                    for (int stringIndex = 0; stringIndex < strings.Count; stringIndex++)
                    {
                        var reversedString = new string(strings[stringIndex].Reverse().ToArray());
                        Console.WriteLine(reversedString.PadLeft(maxLength));
                    }

                    break;
                }
            case 270:
                {
                    var maxLength = strings.Max(x => x.Length);

                    for (int charIndex = maxLength - 1; charIndex >= 0; charIndex--)
                    {
                        for (int stringIndex = 0; stringIndex < strings.Count; ++stringIndex)
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