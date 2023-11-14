namespace UserMangerLib
{
    public class Checker
    {
        public static bool ValidName(string name)
        {
            //check valid name
            return !string.IsNullOrEmpty(name) && name.All(char.IsLetter);
        }
        public static bool ValidAge(string age) 
        {
            //check valid age
            return !string.IsNullOrEmpty(age) && int.TryParse(age, out int ageValue) && ageValue <= 99;
        }
        public static bool ValidPhone(string phone)
        {
            return !string.IsNullOrEmpty(phone) && phone.All(char.IsDigit) && phone.Contains("+");
        }
        public static bool ValidEmail(string email)
        {
            return !string.IsNullOrEmpty(email) && email.Contains("@") && email.Contains(".");
        }
    }
}