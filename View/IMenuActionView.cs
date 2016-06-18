using TadManagementTool.Model;
using TadManagementTool.View.Impl;

namespace TadManagementTool.View
{
    public interface IMenuActionView
    {
        void Open(IMainView mainView);
        bool CanUserAccess(User user);
    }
}
