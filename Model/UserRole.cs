using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TadManagementTool.Model
{
    public enum UserRole
    {
        Administrator = 0,
        Financial = 1,
        Collaborator = 2,
        NonCollaborator = 3
    }

    public static class UserRoleExtensions
    {
        public static string Translate(this UserRole userRole)
        {
            switch (userRole)
            {
                case UserRole.Administrator: return "Administrador";
                case UserRole.Collaborator: return "Colaborador";
                case UserRole.Financial: return "Financeiro";
                case UserRole.NonCollaborator: return "Não Colaborador";
                default: return userRole.ToString();
            }
        }
    }
}
