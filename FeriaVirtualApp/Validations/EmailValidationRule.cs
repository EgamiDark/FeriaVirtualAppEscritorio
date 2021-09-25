using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace FeriaVirtualApp.Validations
{
    public class EmailValidationRule : ValidationRule
    {
        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { _errorMessage = value; }
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            ValidationResult result = new(true, null);
            string emailFromTxt = (value ?? string.Empty).ToString();

            if (emailFromTxt == "")
            {
                result = new ValidationResult(false, ErrorMessage);
            }
            else
            {
                bool isEmail = Regex.IsMatch(emailFromTxt,
                    @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                    RegexOptions.IgnoreCase);

                if (isEmail == false)
                {
                    result = new ValidationResult(false, ErrorMessage);
                }
            }

            return result;
        }
    }
}
