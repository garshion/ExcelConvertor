using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;


namespace Bass.Tools.Log
{
    /// <summary>
    /// Debug Logger
    /// </summary>
    public static class Logger
    {
        public const string LOG_FILE_NAME = "work.log";

        private static object sLock = new object();
        private static List<string> sLogList = new List<string>();

        public static void Log(string message)
        {
#if DEBUG
            StackTrace stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(1);
            MethodBase method = stackFrame.GetMethod();

            lock (sLock)
            {
                sLogList.Add($"{method.Name}() - {message}");
            }
#endif
        }


        public static bool SaveLog()
        {
#if DEBUG

            lock (sLock)
            {
                if (sLogList.Count == 0)
                    return true;

                try
                {
                    string logFilePath = Path.Combine(Environment.CurrentDirectory, LOG_FILE_NAME);

                    using (StreamWriter sw = new StreamWriter(logFilePath, false))  // Overwrite
                    {
                        foreach (string log in sLogList)
                        {
                            sw.WriteLine(log);
                        }
                    }

                    sLogList.Clear();
                }
                catch (Exception ex)
                {
                    Trace(ex);
                    return false;
                }
            }
#endif
            return true;
        }

        public static bool DeleteLogFile()
        {
#if DEBUG
            lock (sLock)
            {
                try
                {
                    string logFilePath = Path.Combine(Environment.CurrentDirectory, LOG_FILE_NAME);
                    if (File.Exists(logFilePath))
                        File.Delete(logFilePath);

                    return true;
                }
                catch (Exception ex)
                {
                    Trace(ex);
                    return false;
                }
            }
#else
            return true;
#endif
        }


        public static void Trace(Exception e)
        {
#if DEBUG
            Console.WriteLine(e.ToString());
#endif
        }

    }
}
