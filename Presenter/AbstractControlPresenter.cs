using TadManagementTool.View;

namespace TadManagementTool.Presenter
{
    public abstract class AbstractControlPresenter<T> where T : IControlView
    {
        public T View { get; private set; }

        public AbstractControlPresenter(T view)
        {
            View = view;
        }
    }
}
