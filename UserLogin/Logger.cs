using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UserLogin
{
    public static class Logger
    {
        private static List<string> currentLogingActivity;


        public static void LogActivity(string activity)
        {
            var activityLine = DateTime.Now + ";" + LoginValidation.CurrentUserUserName + ";" +
                               LoginValidation.currentUserRole + ";" +
                               activity;
            currentLogingActivity.Add(activityLine);

            string path = "log.txt";

            using (StreamWriter sw = File.AppendText(path))
            {
                foreach (var line in currentLogingActivity)
                {
                    sw.WriteLine(line);
                }
            }
        }

        public static void ShowLogActivity()
        {
            try
            {
                // Open the text file using a stream reader.
                using (var sr = new StreamReader("D:\\PS\\log.txt"))
                {
                    // Read the stream as a string, and write the string to the console.
                    Console.WriteLine(sr.ReadToEnd());
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
            }
        }

        // From 2nd EX
        // public static IEnumerable<string> GetSessionActivities()
        // {
        //     try
        //     {
        //         // Open the text file using a stream reader.
        //         using (var sr = new StreamReader("D:\\PS\\log.txt"))
        //         {
        //             // Read the stream as a string, and write the string to the console.
        //             var smth = sr.ReadToEnd();
        //             List<string> activities = new List<string>();
        //             activities.Add(smth);
        //
        //             return activities;
        //         }
        //     }
        //     catch (IOException e)
        //     {
        //         Console.WriteLine("The file could not be read:");
        //         Console.WriteLine(e.Message);
        //         return null;
        //     }
        // }

        public static IEnumerable<string> GetSessionActivities(string filter)
        {
            try
            {
                // Open the text file using a stream reader.
                using (var sr = new StreamReader("D:\\PS\\log.txt"))
                {
                    IEnumerable<string> activities =
                        from line in File.ReadLines("log.txt") where line.Contains(filter) select line;
                    return activities;
                }
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static void ShowCurrentActivity()
        {
            StringBuilder builder = new StringBuilder();
            string s = currentLogingActivity.Last();
            builder.Append(s);
            Console.WriteLine(builder.ToString());
        }

        public static IEnumerable<string> GetCurrentSessionActivities()
        {
            return currentLogingActivity;
        }
    }
}