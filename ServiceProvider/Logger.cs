using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ServiceProvider
{
    internal sealed class Logger
    {
        private static volatile Logger instance;
        private static object syncRoot = new Object();

        private Logger() 
        {
            GenerateFileIfNotExists();
        }
        void GenerateFileIfNotExists()
        {
            try
            {
                string folder = Path.Combine(Environment.GetFolderPath(
                            Environment.SpecialFolder.LocalApplicationData),
                             "UserStoryBook_LogData");
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                    File.Create(Path.Combine(folder, "Log.txt")).Close();
                }
            }
            catch
            {

            }
            
        }
        private string LogPath
        {
            get
            {
                return Path.Combine(Path.Combine(Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData),
                "UserStoryBook_LogData"), "Log.txt");
            }
            
        }
        public static Logger Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                            instance = new Logger();
                    }
                }

                return instance;
            }
        }
        public void LogException(Exception e)
        {
            if (File.Exists(LogPath))
            {
                lock (syncRoot)
                {
                    TextWriter tw = new StreamWriter(LogPath, true);
                    tw.WriteLine(e.Message);
                    tw.Close();
                }
            }
        }

    }
}
