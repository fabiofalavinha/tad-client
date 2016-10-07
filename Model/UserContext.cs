using TadManagementTool.Service;

namespace TadManagementTool.Model
{
    public sealed class UserContext
    {
        private static UserContext instance;

        public static UserContext GetInstance()
        {
            if (instance == null)
                instance = new UserContext();
            return instance;
        }

        private User user;
        private UserProfile userProfile;

        public User LoggedUser
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
                var userProfileService = new UserProfileService();
                var loaded = userProfileService.LoadProfile(user);
                if (loaded == null)
                {
                    loaded = new UserProfile(user);
                }
                Profile = loaded;
            }
        }

        public UserProfile Profile { get; private set; }

        private UserContext()
        {
        }
    }
}
