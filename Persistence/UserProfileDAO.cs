using System.IO;
using System.Xml.Serialization;
using TadManagementTool.Model;

namespace TadManagementTool.Persistence
{
    public class UserProfileDAO : UserPreferencesDAO
    {
        private static readonly string FileExtension = ".xml";

        private string BuildPath(string userId)
        {
            return Path.Combine(BasePath, string.Concat(userId, FileExtension));
        }

        public void SaveProfile(UserProfile profile)
        {
            using (var streamWriter = new StreamWriter(BuildPath(profile.User.Id)))
            {
                new XmlSerializer(typeof(UserProfile)).Serialize(streamWriter, profile);
            }
        }

        public UserProfile LoadProfile(User user)
        {
            var file = new FileInfo(BuildPath(user.Id));
            if (file.Exists)
            {
                using (var fileStream = new FileStream(file.FullName, FileMode.Open))
                {
                    return (UserProfile)new XmlSerializer(typeof(UserProfile)).Deserialize(fileStream);
                }
            }
            return null;
        }
    }
}
