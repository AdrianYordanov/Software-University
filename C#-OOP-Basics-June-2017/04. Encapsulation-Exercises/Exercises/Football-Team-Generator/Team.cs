using System;
using System.Linq;
using System.Collections.Generic;

class Team
{
    private string name;
    private List<Player> players;

    public Team(string name)
    {
        this.Name = name;
        this.players = new List<Player>();
    }

    public string Name
    {
        get
        {
            return this.name;
        }
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("A name should not be empty.");
            }

            this.name = value;
        }
    }

    public int Rating
    {
        get
        {
            return this.players.Count == 0 ? 0 : Convert.ToInt32(Math.Round(this.players.Sum(p => p.Stats) / this.players.Count));
        }
    }

    public void AddPlayer(Player player)
    {
        if (this.IsPlayerInTeam(player.Name))
        {
            throw new InvalidOperationException($"Player {player.Name} already play in {this.Name} team.");
        }

        this.players.Add(player);
    }

    public void RemovePlayer(string playerName)
    {
        if (!this.IsPlayerInTeam(playerName))
        {
            throw new InvalidOperationException($"Player {playerName} is not in {this.Name} team.");
        }

        var player = this.players.FirstOrDefault(n => n.Name == playerName);
        players.Remove(player);
    }

    private bool IsPlayerInTeam(string playerName)
    {
        return this.players.Any(p => p.Name == playerName);
    }

    public override string ToString()
    {
        return $"{this.Name} - {this.Rating}";
    }
}