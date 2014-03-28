namespace ClaimSystem.Sandbox
{
    #region

    using System;

    #endregion

    public class ConsoleLogger
    {
        public static void Information(string message)
        {
            var originalBackgroundColor = Console.BackgroundColor;
            var originalForegroundColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message);
            Console.ForegroundColor = originalForegroundColor;
        }

        public static void Error(string message)
        {
            var originalBackgroundColor = Console.BackgroundColor;
            var originalForegroundColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = originalForegroundColor;
        }
    }
}