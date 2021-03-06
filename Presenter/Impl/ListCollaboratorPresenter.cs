﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TadManagementTool.Model;
using TadManagementTool.Service;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool.Presenter.Impl
{
    public class ListCollaboratorPresenter : AbstractControlPresenter<IListCollaboratorView>, IListCollaboratorPresenter
    {
        private readonly UserProfileService userProfileService;

        public ListCollaboratorPresenter(IListCollaboratorView view)
            : base(view)
        {
            userProfileService = new UserProfileService();
        }

        private void DoSetCollaboratorList(IList<Collaborator> list)
        {
            if (View.IsActiveFilterChecked())
            {
                list = list.Where(c => c.Active == View.IsActiveFilterChecked()).ToArray();
            }
            if (!View.IsNonCollaboratorFilterChecked())
            {
                list = list.Where(c => c.IsCollaborator).ToArray();
            }
            View.SetCollaboratorList(list.Select(c => new CollaboratorViewItem(c)).ToArray(), UserContext.GetInstance().Profile.CollaboratorPreferences);
            View.SetActiveCollaboratorCount(list.Count(c => c.Active));
        }

        public void InitView()
        {
            var task = new Task<IList<Collaborator>>(() =>
            {
                View.ShowWaitingPanel("Carregando colaboradores...");
                var collaboratorService = new CollaboratorService();
                return collaboratorService.FindAll();
            });
            task.ContinueWith(t =>
            {
                DoSetCollaboratorList(t.Result);
                View.HideWaitingPanel();
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao carregar a lista de colaboradores: {0}", innerException.Message));
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }

        public void OnRemoveCollaborator()
        {
            var collaboratorService = new CollaboratorService();
            var task = new Task<CollaboratorViewItem>(() =>
            {
                var collaboratorViewItem = View.GetCollaboratorSelected();
                if (collaboratorViewItem != null)
                {
                    if (View.ShowBinaryQuestion("Deseja excluir este colaborador?"))
                    {
                        View.ShowWaitingPanel(string.Format("Excluindo colaborador - {0}...", collaboratorViewItem.Name));
                        collaboratorService.RemoveCollaborator(collaboratorViewItem.Wrapper);
                    }
                }
                else
                {
                    View.ShowWarningMessage("Selecione o colaborador que deseja excluir");
                }
                return collaboratorViewItem;
            });
            task.ContinueWith(t =>
            {
                var collaboratorViewItem = t.Result;
                if (collaboratorViewItem != null)
                {
                    try
                    {
                        DoSetCollaboratorList(collaboratorService.FindAll());
                    }
                    catch (Exception)
                    {
                        View.ShowWarningMessage(
                            string.Format(
                                "O colaborador {0} foi excluído, porém houve um erro ao atualizar a lista de colaboradores. Por favor, tente entrar nesta opção novamente.", collaboratorViewItem.Name));
                    }
                }
                View.HideWaitingPanel();
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao excluir o colaborador: {0}", innerException.Message));
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }

        public void OnNewCollaborator()
        {
            View.OpenCollaboratorView();
        }

        public void OnViewCollaboratorDetails()
        {
            var collaboratorViewItem = View.GetCollaboratorSelected();
            if (collaboratorViewItem != null)
            {
                View.OpenCollaboratorView(collaboratorViewItem.Wrapper);
            }
            else
            {
                View.ShowWarningMessage("Selecione o colaborador para ver os detalhes");
            }
        }

        public void OnExportToExcel()
        {
            var task = new Task<string>(() =>
            {
                var filePath = View.SelectFilePathToSaveExcelFile();
                if (string.IsNullOrWhiteSpace(filePath))
                {
                    return null;
                }
                View.ShowWaitingPanel("Exportando lista de colaboradores para excel...");
                var collaboratorService = new CollaboratorService();
                collaboratorService.ExportToExcel(View.GetCollaboratorList().Select(i => i.Wrapper).ToArray(), filePath);
                return filePath;
            });
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                if (t.Result != null)
                {
                    View.ShowSuccessMessage(string.Format("Planilha excel foi gerada em '{0}'", t.Result));
                }
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao tentar gerar a tabela: {0}", innerException.Message));
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }

        public void OnSortCollaboratorList(string propertyName, SortOrder sortOrder)
        {
            View.SetCollaboratorList(new ListCollaboratorOrder().Sort(View.GetCollaboratorList(), propertyName, sortOrder), UserContext.GetInstance().Profile.CollaboratorPreferences);
        }

        public void OnSearchCollaborators()
        {
            var task = new Task<IList<Collaborator>>(() =>
            {
                View.ShowWaitingPanel("Filtrando colaboradores...");
                var collaboratorService = new CollaboratorService();
                return collaboratorService.FindAll();
            });
            task.ContinueWith(t =>
            {
                DoSetCollaboratorList(t.Result);
                View.HideWaitingPanel();
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao carregar a lista de colaboradores: {0}", innerException.Message));
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.Start();
        }

        public void OnColumnReOrder(string name, int index)
        {
            var userProfile = UserContext.GetInstance().Profile;
            userProfile.CollaboratorPreferences.ChangeOrder(name, index);
            userProfileService.SaveProfile(userProfile);
        }

        private class ListCollaboratorOrder
        {
            public IList<CollaboratorViewItem> Sort(IList<CollaboratorViewItem> list, string propertyName, SortOrder sortOrder)
            {
                Func<CollaboratorViewItem, object> orderByAction;
                if ("BirthDate".Equals(propertyName))
                {
                    orderByAction = i => i.Wrapper.BirthDate;
                }
                else if ("StartDate".Equals(propertyName))
                {
                    orderByAction = i => i.Wrapper.StartDate.HasValue ? i.Wrapper.StartDate : null;
                }
                else
                {
                    orderByAction = i => i.GetType().GetProperty(propertyName).GetValue(i, null);
                }
                if (sortOrder == SortOrder.Ascending)
                {
                    list = list.OrderBy(orderByAction).ToArray();
                }
                else
                {
                    list = list.OrderByDescending(orderByAction).ToArray();
                }
                return list;
            }
        }
    }
}
