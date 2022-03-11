#if DEBUG

using System;
using System.Runtime.InteropServices;

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

            Printf($"[{CreateTimestamp()}] : Test trace", Severity.TRACE);
            Printf($"[{CreateTimestamp()}] : Test info", Severity.INFO);
            Printf($"[{CreateTimestamp()}] : Test warning", Severity.WARNING);
            Printf($"[{CreateTimestamp()}] : Test error", Severity.ERROR);
            Printf($"[{CreateTimestamp()}] : Test critical", Severity.CRITICAL);
        }

        // Hides console window
        public static void HideDebugConsole()
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SwHide);
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
            return DateTime.Now.ToString();
        }

    }
}

#endif
