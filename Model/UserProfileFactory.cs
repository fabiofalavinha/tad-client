using System.Collections.Generic;

namespace TadManagementTool.Model
{
    public class UserProfileFactory
    {
        public UserProfile CreateProfile(User user)
        {
            var collaboratorPreferences = new CollaboratorPreferences()
            {
                ColumnOrderList = new List<TableColumnPreferences>()
                {
                    new TableColumnPreferences() { Index = 0, Name = "CollaboratorNameColumn" },
                    new TableColumnPreferences() { Index = 1, Name = "CollaboratorEmailColumn" },
                    new TableColumnPreferences() { Index = 2, Name = "BirthDateColumn" },
                    new TableColumnPreferences() { Index = 3, Name = "CollaboratorStartDateColumn" },
                    new TableColumnPreferences() { Index = 4, Name = "CollaboratorGenderColumn" },
                    new TableColumnPreferences() { Index = 5, Name = "CollaboratorTelephoneColumn" },
                    new TableColumnPreferences() { Index = 6, Name = "contributorColumn" },
                    new TableColumnPreferences() { Index = 7, Name = "CollaboratorActiveColumn" }
                }
            };
            return new UserProfile(user, collaboratorPreferences);
        }
    }
}
