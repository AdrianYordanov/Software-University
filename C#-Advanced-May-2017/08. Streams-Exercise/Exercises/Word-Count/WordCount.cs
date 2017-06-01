using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

class WordCount
{
    static void Main()
    {
        var words = new Dictionary<string, int>();

        using (var wordReader = new StreamReader("../../words.txt"))
        {
            var line = string.Empty;

            while ((line = wordReader.ReadLine()) != null)
            {
                var wordTokens = Regex
                        .Split(line.ToLower(), @"\W+");


                foreach (var word in wordTokens)
                {
                    words[word] = 0;
                }
            }

            using (var textReader = new StreamReader("../../text.txt"))
            {
                line = string.Empty;

                while ((line = textReader.ReadLine()) != null)
                {
                    var wordTokens = Regex
                        .Split(line.ToLower(), @"\W+");



                    foreach (var word in wordTokens)
                    {
                        if (words.ContainsKey(word))
                        {
                            words[word]++;
                        }
                    }
                }
            }

            using (var writer = new StreamWriter("../../result.txt"))
            {
                var orderedWords = words.OrderByDescending(x => x.Value);

                foreach (var pair in orderedWords)
                {
                    writer.WriteLine($"{pair.Key} - {pair.Value}");
                }
            }
        }
    }
}
