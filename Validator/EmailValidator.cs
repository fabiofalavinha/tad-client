using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

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
