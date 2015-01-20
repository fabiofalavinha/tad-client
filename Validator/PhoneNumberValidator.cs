using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TadManagementTool.Model;

namespace TadManagementTool.Validator
{
    public class PhoneNumberValidator
    {
        private const string RegexPatternFor9Numbers = "^[9][2-9][0-9]{3}[0-9]{4}$";
        private const string RegexPatternFor8Numbers = "^[2-9][0-9]{3}[0-9]{4}$";

        private readonly int[] AreaCodeFor9Numbers = new int[] { 11, 21, 22, 24, 27, 28 };
        private readonly int phoneAreaCode;
        private readonly PhoneType phoneType;

        public PhoneNumberValidator(int phoneAreaCode, PhoneType phoneType)
        {
            this.phoneAreaCode = phoneAreaCode;
            this.phoneType = phoneType;
        }

        public bool Validate(string input)
        {
            if (phoneType == PhoneType.Mobile && AreaCodeFor9Numbers.Any(a => a == phoneAreaCode))
            {
                return Regex.Match(input, RegexPatternFor9Numbers).Success;
            }
            return Regex.Match(input, RegexPatternFor8Numbers).Success;
        }
    }
}
