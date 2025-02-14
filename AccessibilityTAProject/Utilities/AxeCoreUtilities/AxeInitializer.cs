using System.IO;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium;
using Deque.AxeCore.Selenium;
using AccessibilityTAProject.Utilities.DataUtilities;

namespace AccessibilityTAProject.Utilities.AxeCoreUtilities
{
    public class AxeInitializer
    {
        private static char delim = Path.DirectorySeparatorChar;
        private string pathToAxeConfigFile = DataExtractor.GetFilePath($"Utilities{delim}AxeCoreUtilities{delim}Configurator{delim}AxeConfig.json");

        private static readonly ThreadLocal<AxeBuilder> axeBuilder = new ThreadLocal<AxeBuilder>();
        private static readonly object lockObject = new object();

        private JObject axeConfig = null;
        private List<string> tags = new List<string>();

        private AxeInitializer(IWebDriver webDriver)
        {
            lock (lockObject)
            {
                if (axeConfig == null)
                {
                    axeConfig = (JObject)JsonConvert.DeserializeObject(File.ReadAllText(pathToAxeConfigFile));
                    tags = axeConfig["Tags"].ToObject<string[]>().ToList();
                }
            }

            axeBuilder.Value = new AxeBuilder(webDriver).WithTags(tags.ToArray());
        }

        public static AxeInitializer GetInstance(IWebDriver webDriver)
        {
            return new AxeInitializer(webDriver);
        }

        public AxeBuilder GetAxeBuilder()
        {
            return axeBuilder.Value;
        }
    }
}
