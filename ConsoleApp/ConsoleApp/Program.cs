using System;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Start time: ");
            var startTime = Console.ReadLine();
            Console.Write("End time: ");
            var endTime = Console.ReadLine();

            if (!DateTime.TryParse(startTime, out var startDateTime))
                throw new Exception("Invalid start time");

            if (!DateTime.TryParse(endTime, out var endDateTime))
                throw new Exception("Invalid end time");

            if (endDateTime <= startDateTime)
                throw new Exception("Start time should be before end time");

            double cost = 0;
            DateTime nextPulseTime;
            while (startDateTime <= endDateTime)
            {
                nextPulseTime = startDateTime.AddSeconds(20);
                if ((startDateTime.Hour >= 0 && nextPulseTime.Hour < 9) || (startDateTime.Hour >= 23 && nextPulseTime.Hour < 24))
                    cost += 20;
                else
                    cost += 30;
                startDateTime = nextPulseTime;
            }
            Console.WriteLine(cost / 100 + " taka");
        }
    }
}
