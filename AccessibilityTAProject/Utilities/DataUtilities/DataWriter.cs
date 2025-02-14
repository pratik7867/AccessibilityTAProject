using System.IO;

namespace AccessibilityTAProject.Utilities.DataUtilities
{
    public class DataWriter
    {
        private static readonly object lockObject = new object();

        public static void WriteAllTextToFile(string filePath, string content)
        {
            lock (lockObject)
            {
                File.WriteAllText(filePath, content);
            }
        }

        public static void AppendAllTextToFile(string filePath, string content)
        {
            lock (lockObject)
            {
                File.AppendAllText(filePath, content);
            }
        }
    }
}
