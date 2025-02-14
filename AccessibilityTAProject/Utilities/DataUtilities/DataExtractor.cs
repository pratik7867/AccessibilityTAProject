using System;
using System.IO;
using System.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace AccessibilityTAProject.Utilities.DataUtilities
{
    public class DataExtractor
    {
        private static readonly object lockObject = new object();

        private static char delim = Path.DirectorySeparatorChar;

        public static string pathToAppDataSet = GetFilePath($"Applications{delim}DataSet{delim}");

        public static string GetAppConfigData(string key)
        {
            lock (lockObject)
            {
                return ConfigurationManager.AppSettings[key].ToString();
            }

        }

        public static string GetFilePath(string PathTofile)
        {
            lock (lockObject)
            {
                return Path.Combine(AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin")), PathTofile);
            }
        }

        public static JObject GetAppFileData(string fileName)
        {
            lock (lockObject)
            {
                return (JObject)JsonConvert.DeserializeObject(File.ReadAllText(pathToAppDataSet + fileName));
            }
        }     

    }
}
