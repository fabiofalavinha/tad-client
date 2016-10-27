using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TadManagementTool.Model;

namespace TadManagementTool.View.Impl
{
    public interface IConsecrationEnrollmentView : IDialogView
    {
        void SetElementList(IList<Element> elements);
        void SetComunicationMessage(CommunicationMessage message);
    }
}
