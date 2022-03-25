using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QAAutomationLab.BusinessLayer.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAAutomationLab.BusinessLayer.Services
{
    public static class SettingsService<T>
    {
        public static T GetSettings()
        {
            var pathToData = PathUtility.GetSettingsPath();

            var file = File.ReadAllText(pathToData);

            var settings = JsonConvert.DeserializeObject<T>(file);

            return settings;
        }
    }
}
