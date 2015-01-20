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
            return restTemplate.GetForObject<IList<Collaborator>>("/collaborators");
        }

        public void RemoveCollaborator(Collaborator collaborator)
        {
            restTemplate.Delete("/collaborator/{id}", collaborator.Id);
        }

        public void SaveCollaborator(Collaborator collaborator)
        {
            restTemplate.PostForMessage("/collaborator", collaborator);
        }
    }
}
