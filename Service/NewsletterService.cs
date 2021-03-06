﻿using System.Collections.Generic;
using TadManagementTool.Model;

namespace TadManagementTool.Service
{
    public class NewsletterService : AbstractService
    {
        public IList<NewsletterUser> FindAll()
        {
            return restTemplate.GetForObject<IList<NewsletterUser>>("/newsletters");
        }

        public void SaveNewsletterUser(NewsletterUser newsletterUser)
        {
            restTemplate.PostForMessage("/newsletters", newsletterUser);
        }
        public void RemoveNewsletterUser(NewsletterUser newsletterUser)
        {
            restTemplate.Delete("/newsletter/{id}", newsletterUser.Id);
        }
        public void ExportToExcel(IList<NewsletterUser> newsletterUsers, string filePath)
        {
            var exporter = new ListNewsletterUserExporter();
            exporter.ExportTo(newsletterUsers, filePath);
        }

        public void NotifyPostPublished(Post post)
        {
            restTemplate.PostForMessage("/newsletter/notify/post/{postId}", post, post.Id);
        }
    }
}
