using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QAAutomationLab.BusinessLayer.Utilities
{
    public static class PathUtility
    {
        public static string GetSettingsPath()
        {
            var dataPath = Directory.GetParent(Directory.GetParent(Directory.GetParent(Directory.
                GetCurrentDirectory()).ToString()).ToString()).ToString();
            var fileShortPath = "//TestLayer//Settings//testData.json";
            dataPath = Path.Combine(dataPath, fileShortPath);

            return dataPath;
        }
    }
}
