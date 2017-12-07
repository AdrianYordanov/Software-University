﻿namespace P03_FootballBetting.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Team
    {
        public Team()
        {
            this.HomeGames = new List<Game>();
            this.AwayGames = new List<Game>();
            this.Players = new List<Player>();
        }

        public int TeamId
        {
            get;
            set;
        }

        public decimal Budget
        {
            get;
            set;
        }

        public string Initials
        {
            get;
            set;
        }

        public string LogoUrl
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public int PrimaryKitColorId
        {
            get;
            set;
        }

        public Color PrimaryKitColor
        {
            get;
            set;
        }

        public int SecondaryKitColorId
        {
            get;
            set;
        }

        public Color SecondaryKitColor
        {
            get;
            set;
        }

        public int TownId
        {
            get;
            set;
        }

        public Town Town
        {
            get;
            set;
        }

        [InverseProperty("HomeTeam")]
        public ICollection<Game> HomeGames
        {
            get;
            set;
        }

        [InverseProperty("AwayTeam")]
        public ICollection<Game> AwayGames
        {
            get;
            set;
        }

        public ICollection<Player> Players
        {
            get;
            set;
        }
    }
}