using System;
using System.IO;

namespace TadManagementTool.Persistence
{
    public abstract class UserPreferencesDAO
    {
        protected string BasePath { get; private set; }

        public UserPreferencesDAO()
        {
            BasePath = SetupDirectory();
        }

        private string SetupDirectory()
        {
            var path = new DirectoryInfo(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TAD"));
            if (!path.Exists)
            {
                path.Create();
            }
            return path.FullName;
        }
    }
}
