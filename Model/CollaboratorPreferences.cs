using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Model
{
    public class CollaboratorPreferences
    {
        public List<TableColumnPreferences> ColumnOrderList { get; set; }

        public CollaboratorPreferences()
        {
            ColumnOrderList = new List<TableColumnPreferences>();
            ColumnOrderList.Add(new TableColumnPreferences() { Index = 0, Name = "CollaboratorNameColumn" });
            ColumnOrderList.Add(new TableColumnPreferences() { Index = 1, Name = "CollaboratorEmailColumn" });
            ColumnOrderList.Add(new TableColumnPreferences() { Index = 2, Name = "BirthDateColumn" });
            ColumnOrderList.Add(new TableColumnPreferences() { Index = 3, Name = "CollaboratorStartDateColumn" });
            ColumnOrderList.Add(new TableColumnPreferences() { Index = 4, Name = "CollaboratorGenderColumn" });
            ColumnOrderList.Add(new TableColumnPreferences() { Index = 5, Name = "CollaboratorTelephoneColumn" });
            ColumnOrderList.Add(new TableColumnPreferences() { Index = 6, Name = "contributorColumn" });
            ColumnOrderList.Add(new TableColumnPreferences() { Index = 7, Name = "CollaboratorActiveColumn" });
        }

        public void ChangeOrder(string name, int index)
        {
            foreach (var column in ColumnOrderList)
            {
                if (column.Name.Equals(name))
                {
                    column.Index = index;
                }
            }
        }
    }
}
