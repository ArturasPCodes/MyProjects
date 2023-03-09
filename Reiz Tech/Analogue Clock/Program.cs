namespace Analogue_Clock
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int hour = GetHour();
            int minute = GetMinute();

            /*Logic
            1 hour moves the hour arrow by 30 degrees
            1 min moves the hour arrow by 0.5 degree
            1 min moves the minute arrow by 6 degrees*/

            var minuteArrowDegrees = minute * 6;
            var hourArrowDegrees = hour * 30 + minute * 0.5;
            var angle = Math.Abs(hourArrowDegrees - minuteArrowDegrees);

            var lesserAngle = Math.Min(angle, 360 - angle);

            Console.WriteLine($"The angle is {lesserAngle}");
        }

        private static int GetHour()
        {
            int hour;

            do
            {
                Console.Write("Enter hours between 1 and 12: ");

                if (!int.TryParse(Console.ReadLine(), out hour))
                {
                    Console.WriteLine("The number must be whole, between 1 and 12");
                }
            } while (hour < 1 || hour > 12);

            return hour;
        }

        private static int GetMinute()
        {
            int minute;

            do
            {
                Console.Write("Enter minutes between 0 and 59: ");

                if (!int.TryParse(Console.ReadLine(), out minute))
                {
                    Console.WriteLine("The number must be whole, between 0 and 59");
                }
            } while (minute < 0 || minute > 59);

            return minute;
        }
    }
}