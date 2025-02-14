using System.IO;
using Newtonsoft.Json;
using Deque.AxeCore.Commons;
using AccessibilityTAProject.Utilities.DataUtilities;

namespace AccessibilityTAProject.Utilities.AxeCoreUtilities
{
    public class AxeReportGenerator
    {
        private static readonly object lockObject = new object();
        private static char delim = Path.DirectorySeparatorChar;
        private static string pathToReportDirectory = DataExtractor.GetAppConfigData("PathToReportDirectory");

        public static void CreateResultsOutput(AxeResult result, string TestCaseName)
        {
            string content = JsonConvert.SerializeObject(result, Formatting.Indented);
            lock (lockObject)
            {
                if (!Directory.Exists(pathToReportDirectory))
                {
                    Directory.CreateDirectory(pathToReportDirectory);
                }

                DataWriter.WriteAllTextToFile($"{pathToReportDirectory}{delim}axe-" + TestCaseName + ".json", content);
            }
        }
    }
}
