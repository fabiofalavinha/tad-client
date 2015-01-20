using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model;

namespace TadManagementTool.Service
{
    public class CollaboratorService : AbstractService
    {
        public IList<Collaborator> FindAll()
        {
            return restTemplate.GetForObject<IList<Collaborator>>("/collaborator/all");
        }
    }
}
