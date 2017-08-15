using System;

public class WeeklyEntry : IComparable<WeeklyEntry>
{
    private readonly WeekDay weekDay;
    private string notes;

    public WeeklyEntry(string weekDay, string notes)
    {
        Enum.TryParse(weekDay, out this.weekDay);
        this.Notes = notes;
    }

    public WeekDay WeekDay => this.weekDay;

    public string Notes
    {
        get => this.notes;
        set => this.notes = value;
    }

    public int CompareTo(WeeklyEntry other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }

        if (ReferenceEquals(null, other))
        {
            return 1;
        }

        var result = this.WeekDay.CompareTo(other.WeekDay);
        if (result == 0)
        {
            result = string.Compare(this.Notes, this.Notes, StringComparison.Ordinal);
        }

        return result;
    }

    public override string ToString()
    {
        return $"{this.WeekDay} - {this.Notes}";
    }
}