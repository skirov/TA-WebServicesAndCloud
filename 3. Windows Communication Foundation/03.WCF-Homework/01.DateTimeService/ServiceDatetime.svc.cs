using System;
using System.Globalization;

namespace _01.DateTimeService
{
    public class ServiceDatetime : IServiceDatetime
    {
        public string GetWeekDay(DateTime date)
        {
            string dayOfWeek;

            dayOfWeek = date.ToString("dddd", new CultureInfo("bg-BG"));

            return dayOfWeek;
        }
    }
}
