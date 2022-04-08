using System.IO;

namespace QAAutomationLab.BusinessLayer.Utilities
{
    public static class PathUtility
    {
        public static string GetSettingsPath()
        {
            var dataPath = Directory.GetParent(Directory.
                GetCurrentDirectory()).Parent.Parent.ToString();
            var fileShortPath = "Settings\\testData.json";
            dataPath = Path.Combine(dataPath, fileShortPath);

            return dataPath;
        }

        public static string GetDriverPath()
        {
            var dataPath = Directory.GetParent(Directory.
                GetCurrentDirectory()).Parent.Parent.Parent.ToString();
            var fileShortPath = "QAAutomationLab.CoreLayer\\Files";
            dataPath = Path.Combine(dataPath, fileShortPath);

            return dataPath;
        }
    }
}
