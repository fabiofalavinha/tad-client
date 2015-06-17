using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model;

namespace TadManagementTool.Service
{
    public class PostService : AbstractService
    {
        public IList<Post> findPosts(User user)
        {
            return restTemplate.GetForObject<IList<Post>>("/posts/{userId}", user.Id);
        }
    }
}
