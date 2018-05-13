using System;

public class DateModifier
{
    public DateModifier(string firstDate, string secondDate)
    {
        var isFirstParsed = DateTime.TryParse(firstDate, out var first);
        var isSecondParsed = DateTime.TryParse(secondDate, out var second);
        if (isFirstParsed && isSecondParsed)
        {
            this.Result = Math.Abs((first - second).TotalDays);
        }
        else
        {
            throw new ArgumentException("Invalid Dates");
        }
    }

    public double Result { get; }
}