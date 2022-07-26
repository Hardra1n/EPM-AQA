﻿using System.IO;
using Newtonsoft.Json;
using QAAutomationLab.BusinessLayer.Utilities;

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
