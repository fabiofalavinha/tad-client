using System;
using System.Net.Mail;

namespace TadManagementTool.Validator
{
    public class EmailValidator
    {
        public bool Validate(string input)
        {
            try
            {
                new MailAddress(input);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
