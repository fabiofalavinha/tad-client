using TadManagementTool.View;

namespace TadManagementTool.Presenter
{
    public abstract class AbstractDialogPresenter<T> where T : IDialogView
    {
        public T View { get; private set; }

        public AbstractDialogPresenter(T view)
        {
            View = view;
        }
    }
}
