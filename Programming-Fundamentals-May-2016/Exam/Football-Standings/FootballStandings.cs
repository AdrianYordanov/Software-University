using System;
using System.Linq;
using System.Collections.Generic;

class FootballStandings
{
    static void Main()
    {
        string decryptionKey = Console.ReadLine();
        string line = string.Empty;

        Dictionary<string, int[]> teams = new Dictionary<string, int[]>();

        while ((line = Console.ReadLine()) != "final")
        {
            var tokens = line.Split(' ');
            var goals = GetGoals(tokens[2]);
            string firstTeam = DecrpytTeam(tokens[0], decryptionKey);
            string secondTeam = DecrpytTeam(tokens[1], decryptionKey);

            AddGoalsToTeam(teams, firstTeam, goals[0]);
            AddGoalsToTeam(teams, secondTeam, goals[1]);
            AddPointsToTheTwoTeams(teams, firstTeam, secondTeam, goals[0], goals[1]);
        }

        var scoreSorted = teams
           .OrderByDescending(x => x.Value[1])
           .ThenBy(x => x.Key)
           .ToDictionary(t => t.Key, t => t.Value);

        var goalSorted = teams
            .OrderByDescending(x => x.Value[0])
            .ThenBy(x => x.Key)
            .ToDictionary(t => t.Key, t => t.Value);

        PrintData(scoreSorted, goalSorted);
    }

    private static void PrintData(Dictionary<string, int[]> scoreSorted, Dictionary<string, int[]> goalSorted)
    {
        Console.WriteLine("League standings:");
        int counter = 1;
        foreach (var team in scoreSorted)
        {
            Console.WriteLine("{0}. {1} {2}", counter, team.Key, team.Value[1]);
            ++counter;
        }

        Console.WriteLine("Top 3 scored goals:");
        counter = 0;
        foreach (var team in goalSorted)
        {
            Console.WriteLine("- {1} -> {2}", counter, team.Key, team.Value[0]);
            ++counter;
            if (counter == 3)
            {
                break;
            }
        }

    }

    private static string DecrpytTeam(string team, string decrptionKey)
    {
        team = "justText" + team;
        team += "justText";
        var tokens = team.Split(new string[] { decrptionKey }, StringSplitOptions.None);
        string teamDecrypted = ReverseString(tokens[1]).ToUpper();
        return teamDecrypted;
    }

    private static string ReverseString(string str)
    {
        char[] charArray = str.ToCharArray();
        Array.Reverse(charArray);
        return new string(charArray);
    }

    private static int[] GetGoals(string str)
    {
        var scores = str
                .Split(':')
                .Select(int.Parse)
                .ToArray();

        return scores;
    }

    private static void AddGoalsToTeam(Dictionary<string, int[]> teams, string teamName, int teamGoals)
    {
        var scoresArray = new int[2] { teamGoals, 0 };

        if (teams.ContainsKey(teamName))
        {
            teams[teamName][0] += teamGoals; // Add to goals value.
        }
        else
        {
            teams.Add(teamName, scoresArray);
        }
    }

    private static void AddPointsToTheTwoTeams(Dictionary<string, int[]> teams,
        string firstTeamName, string secondTeamName,
        int firstTeamGoals, int secondTeamGoals)
    {
        if (firstTeamGoals == secondTeamGoals)
        {
            teams[firstTeamName][1]++;
            teams[secondTeamName][1]++;
        }
        else
        {
            if (firstTeamGoals > secondTeamGoals)
            {
                teams[firstTeamName][1] += 3;
            }
            else
            {
                teams[secondTeamName][1] += 3;
            }
        }
    }
}