using TadManagementTool.View.Impl;

namespace TadManagementTool.Presenter.Impl
{
    public class MainPresenter : AbstractPresenter<IMainView>, IMainPresenter
    {
        public MainPresenter(IMainView mainView)
            : base(mainView)
        {
        }

        public void InitView()
        {
        }
    }
}
