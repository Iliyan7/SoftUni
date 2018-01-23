using System;

namespace DateModifier
{
    public class DateModifier
    {
        public static string GetDifference(string strDate1, string strDate2)
        {
            var date1 = DateTime.Parse(strDate1);
            var date2 = DateTime.Parse(strDate2);

            var difference = date1.Subtract(date2);

            return Math.Abs(difference
                .TotalDays)
                .ToString();
                
        }
    }
}
