using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TadManagementTool.Model;
using TadManagementTool.Service;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool.Presenter.Impl
{
    public class ConsecrationEnrollmentPresenter : AbstractDialogPresenter<IConsecrationEnrollmentView>, IConsecrationEnrollmentPresenter
    {
        private readonly EventService eventService;
        private readonly CollaboratorService collaboratorService;
        private readonly IConsecrationInitializationStrategy strategy;
        private Consecration consecration;
        

        public ConsecrationEnrollmentPresenter(IConsecrationEnrollmentView view, IConsecrationInitializationStrategy strategy)
            : base(view)
        {
            this.strategy = strategy;
            eventService = new EventService();
            collaboratorService = new CollaboratorService();
        }

        public void InitView()
        {
            var task = new Task<Consecration>(() =>
            {
                View.ShowWaitingPanel("Carregando dados da consagração...");
                View.SetCollaboratorList(collaboratorService.FindAll().Where(c => c.Active).Select(c => new CollaboratorViewItem(c)).ToArray());
                View.SetElementUnitList(CreateElementUnitList());
                consecration = strategy.GetConsecration();
                return consecration;
            });
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage($"Ocorreu um erro ao carregar os dados da consagração. Tente repetir a operação. {innerException.Message}");
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                var consecration = t.Result;
                if (consecration != null)
                {
                    View.SetElementList(consecration.Elements.Select(e => new ElementViewItem(e)).ToArray());
                    if (consecration.Message != null)
                    {
                        View.SetCommunicationMessage(consecration.Message);
                    }
                }
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.Start();
        }

        private ElementUnitViewItem[] CreateElementUnitList()
        {
            var list = new List<ElementUnitViewItem>();
            list.Add(new ElementUnitViewItem(ElementUnit.None));
            list.Add(new ElementUnitViewItem(ElementUnit.Box));
            list.Add(new ElementUnitViewItem(ElementUnit.Kg));
            list.Add(new ElementUnitViewItem(ElementUnit.Pack));
            list.Add(new ElementUnitViewItem(ElementUnit.Pot));
            list.Add(new ElementUnitViewItem(ElementUnit.Sack));
            return list.ToArray();
        }

        public void OnSaveConsecration()
        {
            var task = new Task(() =>
            {
                if (consecration == null)
                {
                    consecration = new Consecration();
                }
                var elements = View.GetElements();
                var message = View.GetMailContent();

                consecration.Elements = elements.Select(e => e.Wrapper).ToList();
                consecration.Message = new CommunicationMessage(message);

            });
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage($"Ocorreu um erro ao salvar os dados da consagração. Tente repetir a operação. {innerException.Message}");
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.Start();
        }
    }
}
