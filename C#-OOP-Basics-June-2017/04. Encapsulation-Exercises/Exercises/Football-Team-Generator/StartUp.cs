using System;
using System.Collections.Generic;
using System.Linq;

class StartUp
{
    static void Main()
    {
        var teams = new List<Team>();
        var input = string.Empty;

        while ((input = Console.ReadLine()) != "END")
        {
            try
            {
                var tokens = input.Split(';');
                var teamExists = teams.Any(t => t.Name == tokens[1]);

                switch (tokens[0].ToLower())
                {
                    case "team":
                        {
                            if (teamExists)
                            {
                                throw new InvalidOperationException($"Team {tokens[1]} already exist.");
                            }

                            teams.Add(new Team(tokens[1]));
                            break;
                        }
                    case "add":
                        {
                            if (!teamExists)
                            {
                                throw new InvalidOperationException($"Team {tokens[1]} does not exist.");
                            }

                            var newPlayer = new Player(tokens[2], double.Parse(tokens[3]), double.Parse(tokens[4]),
                                double.Parse(tokens[5]), double.Parse(tokens[6]), double.Parse(tokens[7]));
                            var team = teams.FirstOrDefault(t => t.Name == tokens[1]);
                            team.AddPlayer(newPlayer);
                            break;
                        }
                    case "remove":
                        {
                            if (!teamExists)
                            {
                                throw new InvalidOperationException($"Team {tokens[1]} does not exist.");
                            }

                            var team = teams.FirstOrDefault(t => t.Name == tokens[1]);
                            team.RemovePlayer(tokens[2]);
                            break;
                        }
                    case "rating":
                        {
                            if (!teamExists)
                            {
                                throw new InvalidOperationException($"Team {tokens[1]} does not exist.");
                            }

                            var team = teams.FirstOrDefault(n => n.Name == tokens[1]);
                            Console.WriteLine(team);
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}