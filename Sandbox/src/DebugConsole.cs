#if DEBUG

//// Comment the following line to disable dumping logging to "log.txt" file ///
//#define ENABLE_LOGGING_TO_FILE

////////////////////////////////////////////////////////////////////////////////


using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Sandbox.src
{

    internal enum Severity
    {
        TRACE,
        INFO,
        WARNING,
        ERROR,
        CRITICAL
    }

    internal static class DebugConsole
    {
        [DllImport(@"kernel32.dll", SetLastError = true)]
        static extern bool AllocConsole();

        [DllImport(@"kernel32.dll")]
        static extern IntPtr GetConsoleWindow();

        [DllImport(@"user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        const int SwHide = 0;
        const int SwShow = 5;

        // Creates Console window
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
        public static void HideDebugConsole()
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SwHide);
        }

        // Trace message access point function
        public static void Trace(string message)
        {
            Printf($"{CreateTimestamp()} {message}", Severity.TRACE);

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [TRACE]", message);
#endif
        }

        // Information message access point function
        public static void Info(string message)
        {
            Printf($"{CreateTimestamp()} {message}", Severity.INFO);

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [INFO]", message);
#endif
        }

        // Warning message access point function
        public static void Warn(string message)
        {
            Printf($"{CreateTimestamp()} {message}", Severity.WARNING);

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [WARNING]", message);
#endif
        }

        // Error message access point function
        public static void Error(string message)
        {
            Printf($"{CreateTimestamp()} {message}", Severity.ERROR);

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [ERROR]", message);
#endif
        }

        // Critical message access point function
        public static void Critical(string message)
        {
            Printf($"{CreateTimestamp()} {message}", Severity.CRITICAL);

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [CRITICAL]", message);
#endif
        }



        // Colorize debug message strings according to there severity
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
        private static void LogToFile(string ?path, string metadata, string message)
        {
            string filePath = path == null ? $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\log.txt" : path;

            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine($"{metadata} {message}");
            }

        }


    }
}

#endif
