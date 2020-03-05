using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS_Project
{
    static class Logger
    {
        private static readonly string fileName = "C:/Users/Pavlin/Projects/CSharp/PS-Project/PS-Project/log.txt";
        private static List<string> currentSessionActivities = new List<string>();

        public static void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";"
                + LoginValidation.Username + ";"
                + LoginValidation.CurrentUserRole + ";"
                + activity;

            currentSessionActivities.Add(activityLine);
            WriteLineToFile(activityLine);
        }

        private static void WriteLineToFile(string line)
        {
            if (File.Exists(fileName))
            { 
                File.AppendAllText(fileName, line + "\n");
            }
        }

        public static void DumpLog()
        {
            foreach (string item in currentSessionActivities)
            {
                Console.WriteLine(item);
            }
        }

        public static string GetCurrentSessionActivities()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var activities in currentSessionActivities)
            {
                sb.Append(activities);
            }
            return sb.ToString();
        }
    }
}
