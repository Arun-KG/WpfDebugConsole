//#define ENABLE_LOGGING_TO_FILE

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

        /// <summary>
        /// Debug Console initializer 
        /// </summary>
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
        }

        // Hides console window
        [Conditional("DEBUG")]
        public static void HideDebugConsole()
        {
            var handle = GetConsoleWindow();
            ShowWindow(handle, SwHide);
        }

        // TRACE function & overloads /////////////////////////////////////// 
        /// <summary>
        /// Logs "message" as a TRACE to the console
        /// </summary>
        /// <param name="message"></param>
        [Conditional("DEBUG")]
        public static void Trace(string message)
        {
            PrepareConsole(Severity.TRACE);
            Console.WriteLine($"{CreateTimestamp()} {message}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [TRACE]", message);
#endif
        }
        public static void Trace(object? value)
        {
            PrepareConsole(Severity.TRACE);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [TRACE]", value == null ? "null" : value.ToString());
#endif
        }
        public static void Trace(bool value)
        {
            PrepareConsole(Severity.TRACE);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [TRACE]", value.ToString());
#endif
        }
        public static void Trace(char charecter)
        {
            PrepareConsole(Severity.TRACE);
            Console.WriteLine($"{CreateTimestamp()} {charecter}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [TRACE]", charecter.ToString());
#endif
        }
        public static void Trace(char[]? buffer)
        {
            PrepareConsole(Severity.TRACE);
            Console.WriteLine($"{CreateTimestamp()} {buffer}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [TRACE]", buffer == null ? "null" : new string(buffer));
#endif
        }
        public static void Trace(decimal value)
        {
            PrepareConsole(Severity.TRACE);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [TRACE]", value.ToString());
#endif
        }
        public static void Trace(double value)
        {
            PrepareConsole(Severity.TRACE);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [TRACE]", value.ToString());
#endif
        }
        public static void Trace(Int32 value)
        {
            PrepareConsole(Severity.TRACE);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [TRACE]", value.ToString());
#endif
        }
        public static void Trace(Int64 value)
        {
            PrepareConsole(Severity.TRACE);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [TRACE]", value.ToString());
#endif
        }
        public static void Trace(UInt32 value)
        {
            PrepareConsole(Severity.TRACE);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [TRACE]", value.ToString());
#endif
        }
        public static void Trace(UInt64 value)
        {
            PrepareConsole(Severity.TRACE);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [TRACE]", value.ToString());
#endif
        }
        // TRACE function & overloads ends //////////////////////////////////

        // INFO function & overloads ////////////////////////////////////////
        /// <summary>
        /// Logs "message" as a INFORMATION to the console
        /// </summary>
        /// <param name="message"></param>
        [Conditional("DEBUG")]
        public static void Info(string message)
        {
            PrepareConsole(Severity.INFO);
            Console.WriteLine($"{CreateTimestamp()} {message}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [INFO]", message);
#endif
        }
        public static void Info(object? value)
        {
            PrepareConsole(Severity.INFO);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [INFO]", value == null ? "null" : value.ToString());
#endif
        }
        public static void Info(bool value)
        {
            PrepareConsole(Severity.INFO);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [INFO]", value.ToString());
#endif
        }
        public static void Info(char charecter)
        {
            PrepareConsole(Severity.INFO);
            Console.WriteLine($"{CreateTimestamp()} {charecter}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [INFO]", charecter.ToString());
#endif
        }
        public static void Info(char[]? buffer)
        {
            PrepareConsole(Severity.INFO);
            Console.WriteLine($"{CreateTimestamp()} {buffer}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [INFO]", buffer == null ? "null" : new string(buffer));
#endif
        }
        public static void Info(decimal value)
        {
            PrepareConsole(Severity.INFO);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [INFO]", value.ToString());
#endif
        }
        public static void Info(double value)
        {
            PrepareConsole(Severity.INFO);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [INFO]", value.ToString());
#endif
        }
        public static void Info(Int32 value)
        {
            PrepareConsole(Severity.INFO);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [INFO]", value.ToString());
#endif
        }
        public static void Info(Int64 value)
        {
            PrepareConsole(Severity.INFO);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [INFO]", value.ToString());
#endif
        }
        public static void Info(UInt32 value)
        {
            PrepareConsole(Severity.INFO);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [INFO]", value.ToString());
#endif
        }
        public static void Info(UInt64 value)
        {
            PrepareConsole(Severity.INFO);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [INFO]", value.ToString());
#endif
        }
        // INFO function & overloads ends ///////////////////////////////////

        // WARN function & overloads ////////////////////////////////////////
        /// <summary>
        /// Logs "message" as a WARNING to the console
        /// </summary>
        /// <param name="message"></param>
        [Conditional("DEBUG")]
        public static void Warn(string message)
        {
            PrepareConsole(Severity.WARNING);
            Console.WriteLine($"{CreateTimestamp()} {message}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [WARNING]", message);
#endif
        }
        public static void Warn(object? value)
        {
            PrepareConsole(Severity.WARNING);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [WARNING]", value == null ? "null" : value.ToString());
#endif
        }
        public static void Warn(bool value)
        {
            PrepareConsole(Severity.WARNING);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [WARNING]", value.ToString());
#endif
        }
        public static void Warn(char charecter)
        {
            PrepareConsole(Severity.WARNING);
            Console.WriteLine($"{CreateTimestamp()} {charecter}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [WARNING]", charecter.ToString());
#endif
        }
        public static void Warn(char[]? buffer)
        {
            PrepareConsole(Severity.WARNING);
            Console.WriteLine($"{CreateTimestamp()} {buffer}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [WARNING]", buffer == null ? "null" : new string(buffer));
#endif
        }
        public static void Warn(decimal value)
        {
            PrepareConsole(Severity.WARNING);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [WARNING]", value.ToString());
#endif
        }
        public static void Warn(double value)
        {
            PrepareConsole(Severity.WARNING);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [WARNING]", value.ToString());
#endif
        }
        public static void Warn(Int32 value)
        {
            PrepareConsole(Severity.WARNING);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [WARNING]", value.ToString());
#endif
        }
        public static void Warn(Int64 value)
        {
            PrepareConsole(Severity.WARNING);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [WARNING]", value.ToString());
#endif
        }
        public static void Warn(UInt32 value)
        {
            PrepareConsole(Severity.WARNING);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [WARNING]", value.ToString());
#endif
        }
        public static void Warn(UInt64 value)
        {
            PrepareConsole(Severity.WARNING);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [WARNING]", value.ToString());
#endif
        }
        // WARN function & overloads ends ///////////////////////////////////

        // ERROR function & overloads ///////////////////////////////////////
        /// <summary>
        /// Logs "message" as a WARNING to the console
        /// </summary>
        /// <param name="message"></param>
        [Conditional("DEBUG")]
        public static void Error(string message)
        {
            PrepareConsole(Severity.ERROR);
            Console.WriteLine($"{CreateTimestamp()} {message}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [ERROR]", message);
#endif
        }
        public static void Error(object? value)
        {
            PrepareConsole(Severity.ERROR);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [ERROR]", value == null ? "null" : value.ToString());
#endif
        }
        public static void Error(bool value)
        {
            PrepareConsole(Severity.ERROR);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [ERROR]", value.ToString());
#endif
        }
        public static void Error(char charecter)
        {
            PrepareConsole(Severity.ERROR);
            Console.WriteLine($"{CreateTimestamp()} {charecter}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [ERROR]", charecter.ToString());
#endif
        }
        public static void Error(char[]? buffer)
        {
            PrepareConsole(Severity.ERROR);
            Console.WriteLine($"{CreateTimestamp()} {buffer}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [ERROR]", buffer == null ? "null" : new string(buffer));
#endif
        }
        public static void Error(decimal value)
        {
            PrepareConsole(Severity.ERROR);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [ERROR]", value.ToString());
#endif
        }
        public static void Error(double value)
        {
            PrepareConsole(Severity.ERROR);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [ERROR]", value.ToString());
#endif
        }
        public static void Error(Int32 value)
        {
            PrepareConsole(Severity.ERROR);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [ERROR]", value.ToString());
#endif
        }
        public static void Error(Int64 value)
        {
            PrepareConsole(Severity.ERROR);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [ERROR]", value.ToString());
#endif
        }
        public static void Error(UInt32 value)
        {
            PrepareConsole(Severity.ERROR);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [ERROR]", value.ToString());
#endif
        }
        public static void Error(UInt64 value)
        {
            PrepareConsole(Severity.ERROR);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [ERROR]", value.ToString());
#endif
        }
        // ERROR function & overloads ends //////////////////////////////////

        // CRITICAL function & overloads ////////////////////////////////////
        /// <summary>
        /// Logs "message" as CRIRITAL to the console
        /// </summary>
        /// <param name="message"></param>
        [Conditional("DEBUG")]
        public static void Critical(string message)
        {
            PrepareConsole(Severity.CRITICAL);
            Console.WriteLine($"{CreateTimestamp()} {message}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [CRITICAL]", message);
#endif
        }
        public static void Critical(object? value)
        {
            PrepareConsole(Severity.CRITICAL);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [CRITICAL]", value == null ? "null" : value.ToString());
#endif
        }
        public static void Critical(bool value)
        {
            PrepareConsole(Severity.CRITICAL);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [CRITICAL]", value.ToString());
#endif
        }
        public static void Critical(char charecter)
        {
            PrepareConsole(Severity.CRITICAL);
            Console.WriteLine($"{CreateTimestamp()} {charecter}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [CRITICAL]", charecter.ToString());
#endif
        }
        public static void Critical(char[]? buffer)
        {
            PrepareConsole(Severity.CRITICAL);
            Console.WriteLine($"{CreateTimestamp()} {buffer}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [CRITICAL]", buffer == null ? "null" : new string(buffer));
#endif
        }
        public static void Critical(decimal value)
        {
            PrepareConsole(Severity.CRITICAL);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [CRITICAL]", value.ToString());
#endif
        }
        public static void Critical(double value)
        {
            PrepareConsole(Severity.CRITICAL);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [CRITICAL]", value.ToString());
#endif
        }
        public static void Critical(Int32 value)
        {
            PrepareConsole(Severity.CRITICAL);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [CRITICAL]", value.ToString());
#endif
        }
        public static void Critical(Int64 value)
        {
            PrepareConsole(Severity.CRITICAL);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [CRITICAL]", value.ToString());
#endif
        }
        public static void Critical(UInt32 value)
        {
            PrepareConsole(Severity.CRITICAL);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [CRITICAL]", value.ToString());
#endif
        }
        public static void Critical(UInt64 value)
        {
            PrepareConsole(Severity.CRITICAL);
            Console.WriteLine($"{CreateTimestamp()} {value}");
            ResetConsoleColor();

#if ENABLE_LOGGING_TO_FILE
            LogToFile(null, $"{CreateTimestamp()} [CRITICAL]", value.ToString());
#endif
        }
        // CRITICAL function & overloads ends ///////////////////////////////

        /// <summary>
        /// Adds a line break to the console
        /// </summary>
        [Conditional("DEBUG")]
        public static void NewLine()
        {
            Console.WriteLine('\n');
        }

        // Colorize debug message strings according to there severity
        [Conditional("DEBUG")]
        private static void PrepareConsole(Severity severity)
        {
            switch (severity)
            {
                case Severity.TRACE: { Console.ForegroundColor = ConsoleColor.White; break; }
                case Severity.INFO: { Console.ForegroundColor = ConsoleColor.Cyan; break; }
                case Severity.WARNING: { Console.ForegroundColor = ConsoleColor.Yellow; break; }
                case Severity.ERROR: { Console.ForegroundColor = ConsoleColor.Red; break; }
                case Severity.CRITICAL: {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    break;
                }
                default: break;
            }
        }

        [Conditional("DEBUG")]
        private static void ResetConsoleColor()
        {
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
        private static void LogToFile(string? path, string metadata, string message)
        {
            string filePath = path == null ? $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\log.txt" : path;

            using (StreamWriter sw = File.AppendText(filePath))
            {
                sw.WriteLine($"{metadata} {message}");
            }

        }


        // Timing/Performance profiling functions//////////////////////////////////////////////////////////////

        /// <summary>
        /// Starts a profiling timer
        /// </summary>
        /// <param name="name"></param>
        [Conditional("DEBUG")]
        public static void StartProfile(string name)
        {
            Stopwatch timer = new Stopwatch();
            s_timers.Add(new Timers(name, timer));

            timer.Start();
        }

        /// <summary>
        /// Ends the previously started performance profile timer and prints the elapsed time to the console as a INFORMATION message in "Milliseconds (ms)"
        /// </summary>
        [Conditional("DEBUG")]
        public static void StopProfile()
        {
            Timers timer = s_timers[s_timers.Count - 1];
            timer.Watch.Stop();

            Info($"\"{timer.Name}\" took {timer.Watch.ElapsedMilliseconds.ToString()}ms.");

            if (s_timers.Count > 0)
                s_timers.Remove(s_timers[s_timers.Count - 1]);
        }


    }
}

//#endif
