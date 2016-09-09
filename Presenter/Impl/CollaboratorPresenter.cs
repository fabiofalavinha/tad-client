using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TadManagementTool.Model;
using TadManagementTool.Service;
using TadManagementTool.Validator;
using TadManagementTool.View.Impl;
using TadManagementTool.View.Items;

namespace TadManagementTool.Presenter.Impl
{
    public class CollaboratorPresenter : AbstractControlPresenter<ICollaboratorView>, ICollaboratorPresenter
    {
        public CollaboratorPresenter(ICollaboratorView view)
            : base(view)
        {
        }

        private void DoLoadView()
        {
            View.SetUserRoleList(DoGetUserRoleList());
            View.SetPhoneTypeList(DoGetPhoneTypeList());
        }

        public void InitView()
        {
            DoLoadView();
        }

        public void InitViewWith(Collaborator collaborator)
        {
            View.ShowWaitingPanel("Carregando dados do colaborador...");
            try
            {
                DoLoadView();
                if (collaborator != null)
                {
                    View.SetUserRole(collaborator.UserRole);
                    View.SetName(collaborator.Name);
                    View.SetEmail(collaborator.Email);
                    View.SetBirthDate(collaborator.BirthDate);
                    View.SetGenderType(collaborator.Gender);
                    View.SetStartDate(collaborator.StartDate);
                    View.SetReleaseDate(collaborator.ReleaseDate);
                    View.SetTelephoneList(collaborator.Telephones);
                    View.SetContributorEnabled(collaborator.Contributor);
                    View.SetId(collaborator.Id);
                    View.SetObservation(collaborator.Observation);
                }
            }
            finally
            {
                View.HideWaitingPanel();
            }
        }

        private IList<UserRoleViewItem> DoGetUserRoleList()
        {
            var list = new List<UserRoleViewItem>();
            list.Add(new UserRoleViewItem(UserRole.Administrator));
            list.Add(new UserRoleViewItem(UserRole.Collaborator));
            list.Add(new UserRoleViewItem(UserRole.Financial));
            list.Add(new UserRoleViewItem(UserRole.NonCollaborator));
            return list;
        }

        private IList<PhoneTypeViewItem> DoGetPhoneTypeList()
        {
            var list = new List<PhoneTypeViewItem>();
            list.Add(new PhoneTypeViewItem(PhoneType.Home));
            list.Add(new PhoneTypeViewItem(PhoneType.Work));
            list.Add(new PhoneTypeViewItem(PhoneType.Mobile));
            return list;
        }

        public void OnBackToListCollaboratorView()
        {
            View.OpenListCollaboratorView();
        }

        public void OnEnableReleaseDateOption()
        {
            View.SetReleaseDateEnabled(View.IsReleaseDateOptionChecked());
        }

        public void OnEnableStartDateOption()
        {
            View.SetStartDateEnabled(View.IsStartDateOptionChecked());
        }

        public void OnAddTelephone()
        {
            var phoneTypeViewItem = View.GetPhoneTypeSelected();
            if (phoneTypeViewItem == null)
            {
                View.ShowWarningMessage("Selecione o tipo de telefone");
                return;
            }
            var phoneAreaCodeString = View.GetPhoneAreaCode();
            var phoneAreaCodeValidator = new PhoneAreaCodeValidator();
            if (!phoneAreaCodeValidator.Validate(phoneAreaCodeString))
            {
                View.ShowWarningMessage("Código de área inválido");
                return;
            }
            var phoneAreaCode = int.Parse(phoneAreaCodeString);
            var phoneNumberString = View.GetPhoneNumber();
            var phoneNumberValidator = new PhoneNumberValidator(phoneAreaCode, phoneTypeViewItem.Wrapper);
            if (!phoneNumberValidator.Validate(phoneNumberString))
            {
                View.ShowWarningMessage("Número de telefone é inválido");
                return;
            }
            var phoneNumber = int.Parse(phoneNumberString);
            View.AddTelephone(new Telephone()
            {
                PhoneType = phoneTypeViewItem.Wrapper,
                AreaCode = phoneAreaCode,
                Number = phoneNumber
            });
            View.ClearPhoneFields();
        }

        public void OnRemoveTelephone()
        {
            var telephone = View.GetTelephoneSelected();
            if (telephone != null)
            {
                if (View.ShowBinaryQuestion("Deseja excluir este telefone?"))
                {
                    View.RemoveTelephone(telephone);
                }
            }
            else
            {
                if (View.GetTelephoneList().Any())
                {
                    View.ShowWarningMessage("Selecione um telefone a ser excluído");
                }
            }
        }

        public void OnSave()
        {
            var task = new Task<Collaborator>(() =>
            {
                View.ShowWaitingPanel("Salvando dados do colaborador...");
                var userRoleViewItem = View.GetUserRoleSelected();
                if (userRoleViewItem == null)
                {
                    View.ShowWarningMessage("Selecione um tipo de usuário");
                    return null;
                }
                var name = View.GetName();
                if (string.IsNullOrWhiteSpace(name))
                {
                    View.ShowWarningMessage("É obrigatório informar um nome");
                    return null;
                }
                var id = View.GetId();
                var email = View.GetEmail();
                var emailValidator = new EmailValidator();
                if (!emailValidator.Validate(email))
                {
                    View.ShowWarningMessage("Email inválido");
                    return null;
                }
                var birthDate = View.GetBirthDate();
                var genderType = View.GetGenderType();
                if (!genderType.HasValue)
                {
                    View.ShowWarningMessage("Selecione o sexo do colaborador");
                    return null;
                }
                var startDate = View.GetStartDate();
                var telephones = View.GetTelephoneList();
                if (!telephones.Any())
                {
                    View.ShowWarningMessage("Informe pelo menos um telefone");
                    return null;
                }
                var observation = View.GetObservation();
                var contributor = View.GetContributor();
                var collaborator = new Collaborator()
                {
                    Id = id,
                    Name = name,
                    Email = email,
                    Gender = genderType.Value,
                    BirthDate = birthDate,
                    Telephones = telephones.ToArray(),
                    UserRole = userRoleViewItem.Wrapper,
                    Observation = observation,
                    Contributor = contributor
                };
                if (View.IsStartDateOptionChecked())
                {
                    collaborator.StartDate = View.GetStartDate();
                }
                if (View.IsReleaseDateOptionChecked())
                {
                    collaborator.ReleaseDate = View.GetReleaseDate();
                }
                var collaboratorService = new CollaboratorService();
                collaboratorService.SaveCollaborator(collaborator);
                return collaborator;
            });
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                foreach (var innerException in t.Exception.InnerExceptions)
                {
                    View.ShowErrorMessage(string.Format("Ocorreu um erro ao salvar as informações do colaborador: {0}", innerException.Message));
                }
            }, TaskContinuationOptions.OnlyOnFaulted);
            task.ContinueWith(t =>
            {
                View.HideWaitingPanel();
                if (t.Result != null)
                {
                    View.OpenListCollaboratorView();
                }
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.Start();

        }

        public void OnUserRoleChanged()
        {
            var userRole = View.GetUserRoleSelected();
            if (userRole.Wrapper != UserRole.NonCollaborator)
            {
                View.SetStartDateLabelEnabled(true);
                View.SetStartCheckBoxEnabled(true);
                View.SetStartDateEnabled(false);
                View.SetReleaseDateLabelEnabled(true);
                View.SetReleaseCheckBoxEnabled(true);
                View.SetReleaseDateEnabled(false);
            }
            else
            {
                View.SetStartDateLabelEnabled(false);
                View.SetStartCheckBoxEnabled(false);
                View.SetStartDateEnabled(false);
                View.SetReleaseDateLabelEnabled(false);
                View.SetReleaseCheckBoxEnabled(false);
                View.SetReleaseDateEnabled(false);
            }
        }

        public void OnObservationChanged()
        {
            var observation = View.GetObservation();
            View.SetObservationLimit(2000 - observation.Length);
        }
    }
}
