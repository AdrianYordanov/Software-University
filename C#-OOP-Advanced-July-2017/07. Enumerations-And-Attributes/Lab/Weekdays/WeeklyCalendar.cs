using System.Collections.Generic;

public class WeeklyCalendar
{
    private readonly List<WeeklyEntry> weeklySchedule;

    public WeeklyCalendar()
    {
        this.weeklySchedule = new List<WeeklyEntry>();
    }

    public IEnumerable<WeeklyEntry> WeeklySchedule => this.weeklySchedule.AsReadOnly();

    public void AddEntry(string weekDay, string notes)
    {
        this.weeklySchedule.Add(new WeeklyEntry(weekDay, notes));
    }
}