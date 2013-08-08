using System;
using _02.DateTimeService.Client.DateTimeServiceReference;

namespace _02.DateTimeService.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceDatetimeClient dateTimeTranslator = new ServiceDatetimeClient();

            string datOfWeek = dateTimeTranslator.GetWeekDay(DateTime.Now);

            Console.WriteLine(datOfWeek);
        }
    }
}
