using System.Collections.Generic;

//namespace WeekDays
//{
public class WeeklyCalendar
{
    public WeeklyCalendar()
    {
        this.WeeklySchedule = new List<WeeklyEntry>();
    }

    public List<WeeklyEntry> WeeklySchedule { get; }

    public void AddEntry(string weekday, string notes)
    {
        this.WeeklySchedule.Add(new WeeklyEntry(weekday, notes));
    }
}
//}