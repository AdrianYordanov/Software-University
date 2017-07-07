using System;

class Song
{
    private string artistName;
    private string songName;
    private int minutes;
    private int seconds;

    public Song(string name, string songName, int minutes, int seconds)
    {
        this.ArtistName = name;
        this.SongName = songName;
        this.Minutes = minutes;
        this.Seconds = seconds;
    }

    public int Seconds
    {
        get
        {
            return this.seconds;
        }
        set
        {
            if (value < 0 || value > 59)
            {
                throw new InvalidSongSecondsException();
            }

            this.seconds = value;
        }
    }

    public int Minutes
    {
        get
        {
            return this.minutes;
        }
        set
        {
            if (value < 0 || value > 14)
            {
                throw new InvalidSongMinutesException();
            }

            this.minutes = value;
        }
    }

    public string SongName
    {
        get
        {
            return this.songName;
        }
        set
        {
            if (value.Length < 3 || value.Length > 30)
            {
                throw new InvalidSongNameException();
            }

            this.songName = value;
        }
    }

    public string ArtistName
    {
        get
        {
            return this.artistName;
        }
        set
        {
            if (value.Length < 3 || value.Length > 20)
            {
                throw new InvalidArtistNameException();
            }

            this.artistName = value;
        }
    }

    public TimeSpan SongLength
    {
        get
        {
            return TimeSpan.FromSeconds(this.Minutes * 60 + this.Seconds);
        }
    }
}