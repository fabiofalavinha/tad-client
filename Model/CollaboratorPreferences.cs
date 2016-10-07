using System.Collections.Generic;
using System.Linq;

namespace TadManagementTool.Model
{
    public class CollaboratorPreferences
    {
        private class TableColumnPreferencesComparer : IComparer<TableColumnPreferences>
        {
            public int Compare(TableColumnPreferences x, TableColumnPreferences y)
            {
                if (x.Index == y.Index)
                {
                    return 0;
                }
                return x.Index > y.Index ? 1 : -1;
            }
        }

        public List<TableColumnPreferences> ColumnOrderList { get; set; }

        public void ChangeOrder(string name, int index)
        {
            foreach (var column in ColumnOrderList)
            {
                if (column.Name.Equals(name))
                {
                    column.Index = index;
                }
            }
            ColumnOrderList.Sort(new TableColumnPreferencesComparer());
        }

        public TableColumnPreferences GetColumn(string name)
        {
            return ColumnOrderList.Single(c => c.Name.Equals(name));
        }
    }
}
