using System;

class InvalidSongException : Exception
{
    public override string Message => "Invalid song.";
}