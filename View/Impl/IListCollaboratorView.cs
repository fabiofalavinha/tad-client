using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model;

namespace TadManagementTool.View.Impl
{
    public interface IListCollaboratorView : IControlView
    {
        void SetCollaboratorList(IList<Collaborator> list);
    }
}
