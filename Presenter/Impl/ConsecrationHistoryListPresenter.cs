using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TadManagementTool.Model;
using TadManagementTool.Presenter.Impl;
using TadManagementTool.Service;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool.Presenter
{
    public class ConsecrationHistoryListPresenter : AbstractControlPresenter<IConsecrationHistoryListView>, IConsecrationHistoryListPresenter
    {
        private readonly EventService eventService;

        public ConsecrationHistoryListPresenter(IConsecrationHistoryListView view)
            : base(view)
        {
            eventService = new EventService();
        }

        public void InitView()
        {
            var task = new Task<IList<Consecration>>(() =>
            {
                View.ShowWaitingPanel("Carregando dados das consagrações...");
                return eventService.FindAllConsecrations();
            });
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage($"Ocorreu um erro ao carregar os dados das consagrações. Tente repetir a operação. {innerException.Message}");
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                var consecrations = t.Result;

                if (consecrations != null)
                {
                    View.SetConsecrationList(consecrations.Select(c => new ConsecrationViewItem(c)).ToArray());
                }
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.Start();
        }

        public void OnSelectConsecrationHistoryView()
        {
            var selected = View.GetConsecrationSelected();
            if (selected != null)
            {
                var result = View.OpenConsecrationHistoryDetails(new ConsecrationHistoryInitializationStrategy(selected.Wrapper));
            }
            
        }
    }
}
