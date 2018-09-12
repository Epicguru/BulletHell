using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulletHell
{
    /// <summary>
    /// Contains all the logging (console) functionality, and also some other debugging utlities such as timers.
    /// Should always be used instead of Console class.
    /// </summary>
    public static class Log
    {
        public const bool PRINT_SENDER = true;
        public const bool PRINT_TAG = true;

        private const string DEBUG = "[DEBUG] ";
        private const string TRACE = "[TRACE] ";
        private const string WARNING = "[WARN] ";
        private const string ERROR = "[ERROR] ";
        private const string NULL = "(null)";
        private const string TIME_LOG_PREFIX = "TL:";

        private static Dictionary<string, Stopwatch> timers = new Dictionary<string, Stopwatch>();
        private static List<string> timeLogs = new List<string>();
        private static StringBuilder str = new StringBuilder();

        // Logging utilities:

        public static void Error(object message)
        {
            str.Clear();

            if (PRINT_TAG)
                str.Append(ERROR);

            if (message != null)
                str.Append(message);
            else
                str.Append(NULL);

            Output(str.ToString(), ConsoleColor.Red);
        }

        public static void Warn(object message)
        {
            str.Clear();

            if (PRINT_TAG)
                str.Append(WARNING);

            if (message != null)
                str.Append(message);
            else
                str.Append(NULL);

            Output(str.ToString(), ConsoleColor.Yellow);
        }

        public static void Debug(object message)
        {
            str.Clear();

            if(PRINT_TAG)
                str.Append(DEBUG);

            if (message != null)
                str.Append(message);
            else
                str.Append(NULL);

            Output(str.ToString(), ConsoleColor.White);
        }

        public static void Trace(object message)
        {
            str.Clear();

            if (PRINT_TAG)
                str.Append(TRACE);

            if (message != null)
                str.Append(message);
            else
                str.Append(NULL);

            Output(str.ToString(), ConsoleColor.Gray);
        }

        private static void Output(string text, ConsoleColor colour = ConsoleColor.White)
        {
            if(Console.ForegroundColor != colour)
            {
                Console.ForegroundColor = colour;
            }

            Console.WriteLine(text);
        }

        // Timer utilities:

        public static void StartTimer(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return;

            if (!timers.ContainsKey(name))
            {
                var watch = new Stopwatch();
                watch.Start();
                timers.Add(name, watch);
            }
        }

        public static TimeSpan CheckTimer(string name)
        {
            if (!timers.ContainsKey(name))
            {
                return TimeSpan.MinValue;
            }
            else
            {
                return timers[name].Elapsed;
            }
        }

        public static TimeSpan EndTimer(string name)
        {

            if (!timers.ContainsKey(name))
            {
                return TimeSpan.MinValue;
            }
            else
            {
                var span = timers[name].Elapsed;
                timers[name].Stop();
                timers.Remove(name);
                return span;
            }
        }

        public static void StartTimeLog(string sectionName)
        {
            if (string.IsNullOrWhiteSpace(sectionName))
                return;

            string timerName = TIME_LOG_PREFIX + sectionName.Trim();
            timeLogs.Add(sectionName);

            StartTimer(timerName);
        }

        public static TimeSpan EndTimeLog(bool trace = false)
        {
            if (timeLogs.Count == 0)
                return TimeSpan.MinValue;

            string timerName = timeLogs[timeLogs.Count - 1];
            var span = EndTimer(timerName);
            string sectionName = timerName.Replace(TIME_LOG_PREFIX, "");

            if (trace)
            {
                // Do trace print.
                Log.Trace("Completed " + sectionName + " in " + span.TotalMilliseconds + "ms.");
            }
            else
            {
                // Do debug print.
                Log.Debug("Completed " + sectionName + " in " + span.TotalMilliseconds + "ms.");
            }

            return span;
        }
    }
}
