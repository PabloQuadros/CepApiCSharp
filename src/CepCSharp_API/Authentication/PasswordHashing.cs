using System.Text;

namespace CepCSharp_API.Authentication
{
    public static class PasswordHashing
    {
        public static string HashPassword(string password)
        {
            StringBuilder hashedPassword = new StringBuilder();

            for (int i = 0; i < password.Length; i++)
            {
                char currentChar = password[i];
                char previousChar = i > 0 ? password[i - 1] : '\0'; // Pega o caractere anterior ou usa '\0' se for o primeiro caractere.

                int asciiValue = currentChar * (int)previousChar; // Multiplica o valor ASCII do caractere atual pelo valor ASCII do caractere anterior.

                hashedPassword.Append(asciiValue.ToString("X")); // Adiciona o valor resultante em hexadecimal à string resultante.
            }

            return hashedPassword.ToString();
        }

        public static bool VerifyPassword(string hashedPassword, string passwordToVerify)
        {
            string hashedInput = HashPassword(passwordToVerify);
            return string.Equals(hashedPassword, hashedInput);
        }
    }
}
