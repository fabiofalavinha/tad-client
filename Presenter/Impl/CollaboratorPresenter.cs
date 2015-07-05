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
                    View.SetId(collaborator.Id);
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
            var task = new Task(() =>
            {
                View.ShowWaitingPanel("Salvando dados do colaborador...");
                var userRoleViewItem = View.GetUserRoleSelected();
                if (userRoleViewItem == null) {
                    View.ShowWarningMessage("Selecione um tipo de usuário");
                    return;
                }
                var name = View.GetName();
                if (string.IsNullOrWhiteSpace(name))
                {
                    View.ShowWarningMessage("É obrigatório informar um nome");
                    return;
                }
                var id = View.GetId();
                var email = View.GetEmail();
                var emailValidator = new EmailValidator();
                if (!emailValidator.Validate(email))
                {
                    View.ShowWarningMessage("Email inválido");
                    return;
                }
                var birthDate = View.GetBirthDate();
                var genderType = View.GetGenderType();
                if (!genderType.HasValue)
                {
                    View.ShowWarningMessage("Selecione o sexo do colaborador");
                    return;
                }
                var startDate = View.GetStartDate();
                var telephones = View.GetTelephoneList();
                if (!telephones.Any())
                {
                    View.ShowWarningMessage("Informe pelo menos um telefone");
                    return;
                }
                var collaborator = new Collaborator()
                {
                    Id = id,
                    Name = name,
                    Email = email,
                    Gender = genderType.Value,
                    BirthDate = birthDate,
                    StartDate = startDate,
                    Telephones = telephones.ToArray(),
                    UserRole = userRoleViewItem.Wrapper
                };
                if (View.IsReleaseDateOptionChecked())
                {
                    collaborator.ReleaseDate = View.GetReleaseDate();
                }
                var collaboratorService = new CollaboratorService();
                collaboratorService.SaveCollaborator(collaborator);
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
                View.OpenListCollaboratorView();
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            task.Start();
        }
    }
}
