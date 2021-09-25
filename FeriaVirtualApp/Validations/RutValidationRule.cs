using System.Globalization;
using System.Text.RegularExpressions;
using System.Windows.Controls;

namespace FeriaVirtualApp.Validations
{
    public class RutValidationRule : ValidationRule
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

            string rutFromTxt = (value ?? string.Empty).ToString();

            if (rutFromTxt == "")
            {
                result = new ValidationResult(false, ErrorMessage);
            }
            else
            {
                bool validaRut = ValidaRut(rutFromTxt);

                if (validaRut == false)
                {
                    result = new ValidationResult(false, ErrorMessage);
                }
            }

            return result;
        }

        public static bool ValidaRut(string rut)
        {
            // Remueve los punto que se pudieron haber ingresado
            rut = rut.Replace(".", "").ToUpper();

            // Formato validacion tipo regex para rut
            Regex expresion = new Regex("^([0-9]+-[0-9K])$");
            string dv = rut.Substring(rut.Length - 1, 1);

            // Si el rut esta en un formato que no corresponde devolvera falso
            if (!expresion.IsMatch(rut))
            {
                return false;
            }

            char[] charCorte = { '-' };
            string[] rutTemp = rut.Split(charCorte);

            // Si despues de cortar el rut, el dv es diferente devuelvera falso
            if (dv != Digito(int.Parse(rutTemp[0])))
            {
                return false;
            }

            return true;
        }

        /// Método que calcula el digito verificador a partir
        /// de la mantisa del rut
        public static string Digito(int rut)
        {
            int suma = 0;
            int multiplicador = 1;
            while (rut != 0)
            {
                multiplicador++;
                if (multiplicador == 8)
                    multiplicador = 2;
                suma += (rut % 10) * multiplicador;
                rut = rut / 10;
            }
            suma = 11 - (suma % 11);
            if (suma == 11)
            {
                return "0";
            }
            else if (suma == 10)
            {
                return "K";
            }
            else
            {
                return suma.ToString();
            }
        }
    }
}
