using System;
using System.Collections.Generic;
namespace common
{
    public static class LoggingService
    {
        public static void WriteToFile(List<ILoggable> message)
        {
            foreach (var word in message)
            {
                Console.WriteLine(word.Log());

            }
        }
    }
}