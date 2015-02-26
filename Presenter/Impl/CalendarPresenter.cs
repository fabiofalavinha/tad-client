using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TadManagementTool.Model;
using TadManagementTool.Service;
using TadManagementTool.View.Impl;

namespace TadManagementTool.Presenter.Impl
{
    public class CalendarPresenter : AbstractControlPresenter<ICalendarView>, ICalendarPresenter
    {
        private readonly EventService eventService;

        public CalendarPresenter(ICalendarView view)
            : base(view)
        {
            this.eventService = new EventService();
        }

        public void InitView()
        {
            var task = new Task<IList<Event>>(() =>
            {
                View.ShowWaitingPanel("Carregando eventos...");
                return eventService.FindEventByYear(View.GetMonthDaySelected().Year);
            });
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao carregar os eventos: {0}", innerException.Message));
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.ContinueWith(t => 
            {
                View.HideWaitingPanel();
                View.SetEvents(t.Result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.Start();
        }

        public void OnMonthDaySelected()
        {
            var monthDaySelected = View.GetMonthDaySelected();

        }
    }
}
