using System.Reflection;

namespace TadManagementTool
{
    public sealed class ApplicationVersion
    {
        public static string Version { get { return Assembly.GetEntryAssembly().GetName().Version.ToString(); } }

        private ApplicationVersion()
        {
        }
    }
}
