namespace Tilfældigheder
{
    public class Encrypter
    {

        private static char Cipher(char ch, int key)
        {
            if (!char.IsLetter(ch)) return ch;

            char d = char.IsUpper(ch) ? 'A' : 'a';

            return (char) ((ch + key - d) % 26 + d);
        }

        public static string Encipher(string input, int key)
        {
            string result = string.Empty;
            foreach (var c in input)
            {
                result += Cipher(c, key);
            }

            return result;
        }

        public static string Decipher(string input, int key)
        {
            return Encipher(input, 26 - key);
        }
        
    }
}