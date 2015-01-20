using System.Text.RegularExpressions;

namespace TadManagementTool.Validator
{
    public class PhoneAreaCodeValidator
    {
        private const string RegexPattern = "^(10)|([1-9][1-9])$";

        public bool Validate(string input)
        {
            return Regex.Match(input, RegexPattern).Success;
        }
    }
}
