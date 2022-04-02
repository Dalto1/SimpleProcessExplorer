using System.Collections.Generic;
using System.Diagnostics;

namespace ProcessExplorer
{
    internal class Tools
    {
        public static bool KillProcess(string process)
        {
            bool killedSomething = false;
            try
            {
                foreach (Process P in Process.GetProcessesByName(process))
                {
                    try
                    {
                        P.Kill();
                        killedSomething = true;
                    }
                    catch { }
                }
            }
            catch { }
            return killedSomething;
        }
        public static List<string> ListProcess()
        {
            List<string> result = new List<string>();
            foreach (Process P in Process.GetProcesses())
                result.Add(UppercaseFirst(P.ProcessName));
            return result;
        }        
        private static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
                return string.Empty;
            
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
