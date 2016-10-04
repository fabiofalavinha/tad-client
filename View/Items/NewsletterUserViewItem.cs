using TadManagementTool.Model;

namespace TadManagementTool.View.Items
{
    public class NewsletterUserViewItem
    {
        public NewsletterUser Wrapper { get; private set; }
        public string Name { get { return Wrapper.Name; } }
        public string Email { get { return Wrapper.Email; } }
        public string Status { get { return ParseStatus(Wrapper.ToStatus()); } }

        public NewsletterUserViewItem(NewsletterUser newsletterUser)
        {
            Wrapper = newsletterUser;
        }

        private string ParseStatus(NewsletterUserConfirmationStatus status)
        {
            switch (status)
            {
                case NewsletterUserConfirmationStatus.Pending: return "Pendente";
                case NewsletterUserConfirmationStatus.Confirmed: return "Confirmado";
                default: return "N/A";
            }
        }
    }
}
