using TadManagementTool.Model;

namespace TadManagementTool.View.Items
{
    public class ContributorViewItem
    {
        public Collaborator Wrapper { get; private set; }

        public string Id { get { return Wrapper.Id; } }
        public string Name { get { return Wrapper.Name; } }

        public virtual bool IsAllOption { get { return false; } }

        public ContributorViewItem(Collaborator wrapper)
        {
            Wrapper = wrapper;
        }
    }

    public class AllContributorViewItem : ContributorViewItem
    {
        public override bool IsAllOption { get { return true; } }

        public AllContributorViewItem()
            : base(new Collaborator() { Id = "-1", Name = "Todos" })
        {
        }
    }
}
