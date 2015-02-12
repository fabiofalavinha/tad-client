﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model;

namespace TadManagementTool.View.Impl
{
    public interface IListCollaboratorView : IControlView
    {
        Collaborator GetCollaboratorSelected();
        bool ShowBinaryQuestion(string message);
        void SetCollaboratorList(IList<Collaborator> list);
        void OpenCollaboratorView();
        void OpenCollaboratorView(Collaborator collaborator);
    }
}