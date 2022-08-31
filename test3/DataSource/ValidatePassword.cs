using System;
using System.Text.RegularExpressions;

namespace test3.DataSource
{
    public class ValidatePassword
    {
        public static bool PasswordIsValid(string pass)
        {
            var regex = @"^(?!.*(.)\1)(?=.*[A-za-z])(?=.*[0-9])([A-Za-z0-9]){5,12}$";
            Match match = Regex.Match(pass, regex, RegexOptions.IgnoreCase);

            if(pass.Length>12 || pass.Length < 5)
            {
                return false;
            }
            else if(pass != String.Empty) //&& match.Success)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
