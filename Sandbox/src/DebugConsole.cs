//#if DEBUG

//// Comment the following line to disable dumping logging to "log.txt" file ///
//#define ENABLE_LOGGING_TO_FILE

////////////////////////////////////////////////////////////////////////////////


using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace WPFDebugger
{
    public static class DebugConsole
    {
        [DllImport(@"kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        [DllImport(@"kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport(@"user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        private enum Severity
        {
            TRACE,
            INFO,
            WARNING,
            ERROR,
            CRITICAL
        }

        private struct Timers
        {
            public Timers(string name, Stopwatch watch)
            {
                Name = name;
                Watch = watch;
            }

            public string Name;
            public Stopwatch Watch;
        }

        const int SwHide = 0;
        const int SwShow = 5;

        private static List<Timers> s_timers = new List<Timers>();

        // Creates Console window
        [Conditional("DEBUG")]
        public static void InitDebugConsole()
        {
            var handle = GetConsoleWindow();

            if (handle == IntPtr.Zero)
            {
                AllocConsole();
            }
            else
            {
                ShowWindow(handle, SwShow);
            }

            /*Printf($"{CreateTimestamp()} Test trace", Severity.TRACE);
            Printf($"{CreateTimestamp()} Test info", Severity.INFO);
            Printf($"{CreateTimestamp()} Test warning", Severity.WARNING);
            Printf($"{CreateTimestamp()} Test error", Severity.ERROR);
            Printf($"{CreateTimestamp()} Test critical", Severity.CRITICAL);*/
        }

        // Hides console window
        [Conditional("DEBUG")]
        public static void HideDebugConsole()
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SwHide);
        }


        // Debugging messages functions/////////////////////////////////////////////////////////////////////

        // Trace message access point function
        [Conditional("DEBUG")]
        public static void Trace(string message)
        {
            Printf($"{CreateTimestamp()} {message}", Severity.TRACE);

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [TRACE]", message);
#endif
        }

        // Information message access point function
        [Conditional("DEBUG")]
        public static void Info(string message)
        {
            Printf($"{CreateTimestamp()} {message}", Severity.INFO);

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [INFO]", message);
#endif
        }

        // Warning message access point function
        [Conditional("DEBUG")]
        public static void Warn(string message)
        {
            Printf($"{CreateTimestamp()} {message}", Severity.WARNING);

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [WARNING]", message);
#endif
        }

        // Error message access point function
        [Conditional("DEBUG")]
        public static void Error(string message)
        {
            Printf($"{CreateTimestamp()} {message}", Severity.ERROR);

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [ERROR]", message);
#endif
        }

        // Critical message access point function
        [Conditional("DEBUG")]
        public static void Critical(string message)
        {
            Printf($"{CreateTimestamp()} {message}", Severity.CRITICAL);

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [CRITICAL]", message);
#endif
        }

        // Adds a new line character to the console
        [Conditional("DEBUG")]
        public static void NewLine()
        {
            Console.WriteLine('\n');
        }

        // Colorize debug message strings according to there severity
        [Conditional("DEBUG")]
        private static void Printf(string text, Severity severity)
        {
            switch (severity)
            {
                case Severity.TRACE:        { Console.ForegroundColor = ConsoleColor.White;    break; }
                case Severity.INFO:         { Console.ForegroundColor = ConsoleColor.Cyan;     break; }
                case Severity.WARNING:      { Console.ForegroundColor = ConsoleColor.Yellow;   break; }
                case Severity.ERROR:        { Console.ForegroundColor = ConsoleColor.Red;      break; }
                case Severity.CRITICAL:     { 
                                              Console.ForegroundColor = ConsoleColor.White; 
                                              Console.BackgroundColor = ConsoleColor.DarkRed;
                                              break;
                }
                default: break;
            }

            Console.WriteLine(text);

            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }

        // Generates timestamp
        private static string CreateTimestamp()
        {
            string DateTimeString = $"[{DateTime.Now.Day}/{DateTime.Now.Month}/{DateTime.Now.Year} {DateTime.Now.Hour}:{DateTime.Now.Minute}:{DateTime.Now.Second}]";
            return DateTimeString;
        }

        // Logs debug console messages to a specified file in a specified path
        [Conditional("DEBUG")]
        private static void LogToFile(string ?path, string metadata, string message)
        {
            string filePath = path == null ? $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\log.txt" : path;

            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine($"{metadata} {message}");
            }

        }


        // Timing/Performance profiling functions//////////////////////////////////////////////////////////////

        // Start profile function
        [Conditional("DEBUG")]
        public static void StartProfile(string name)
        {
            Stopwatch timer = new Stopwatch();
            s_timers.Add(new Timers(name, timer));

            timer.Start();
        }

        // Stops and creates the result for the last requested timer
        [Conditional("DEBUG")]
        public static void StopProfile()
        {
            Timers timer = s_timers[s_timers.Count - 1];
            timer.Watch.Stop();

            Info($"\"{timer.Name}\" took {timer.Watch.ElapsedMilliseconds.ToString()}ms.");

            if(s_timers.Count > 0)
                s_timers.Remove(s_timers[s_timers.Count - 1]);
        }
    }
}

//#endif
