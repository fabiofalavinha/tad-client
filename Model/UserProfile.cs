namespace TadManagementTool.Model
{
    public class UserProfile
    {
        public User User { get; set; }

        public CollaboratorPreferences CollaboratorPreferences { get; set; }

        protected UserProfile()
        {
        }

        public UserProfile(User user, CollaboratorPreferences collaboratorPreferences)
        {
            User = user;
            CollaboratorPreferences = collaboratorPreferences;
        }
    }
}
