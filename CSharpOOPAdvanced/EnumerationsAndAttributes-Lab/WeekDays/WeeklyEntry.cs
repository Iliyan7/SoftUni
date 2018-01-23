using System;

//namespace WeekDays
//{
public class WeeklyEntry : IComparable<WeeklyEntry>
{
    private WeekDay weekDay;

    public WeeklyEntry(string weekday, string notes)
    {
        Enum.TryParse(weekday, out this.weekDay);
        this.Notes = notes;
    }

    private WeekDay WeekDay => this.weekDay;
    public string Notes { get; private set; }

    public override string ToString()
    {
        return $"{this.weekDay} - {this.Notes}";
    }

    public int CompareTo(WeeklyEntry other)
    {
        if (ReferenceEquals(this, other))
            return 0;

        if (ReferenceEquals(null, other))
            return 1;

        var weekDayComparison = this.weekDay.CompareTo(other.weekDay);

        if (weekDayComparison != 0)
            return weekDayComparison;

        return string.Compare(this.Notes, other.Notes, StringComparison.Ordinal);
    }
}
//}
