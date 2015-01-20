using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace TadManagementTool.Validator
{
    public class EmailValidator
    {
        private const string RegexPattern = "^\b[A-Z0-9._%+-]+@[A-Z0-9.-]+\\.[A-Z]{2,4}\b$";

        public bool Validate(string input)
        {
            return Regex.Match(input, RegexPattern).Success;
        }
    }
}
