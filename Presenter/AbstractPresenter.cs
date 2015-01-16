using TadManagementTool.View;

namespace TadManagementTool.Presenter
{
    public abstract class AbstractPresenter<T> where T : IView
    {
        public T View { get; private set; }

        public AbstractPresenter(T view)
        {
            View = view;
        }
    }
}
