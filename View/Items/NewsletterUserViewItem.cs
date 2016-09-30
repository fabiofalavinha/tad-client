using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model;

namespace TadManagementTool.View.Items
{
    public class NewsletterUserViewItem
    {
        public NewsletterUser Wrapper { get; private set; }
        public string Name { get { return Wrapper.Name; } }
        public string Email { get { return Wrapper.Email; } }

        public NewsletterUserViewItem(NewsletterUser newsletterUser)
        {
            Wrapper = newsletterUser;
        }
    }
}
