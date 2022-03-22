using System;
using System.Linq;
using System.Windows;

namespace WpfApp1.Model
{
    internal class TrithemiusCipher
    {
        // Russian Alphabet without "Ё"
        private Char[] _russianAlphabet = Enumerable.Range('А', 'Я' - 'А' + 1) 
                                                    .Select(Convert.ToChar)    
                                                    .Concat("Ё .,")            
                                                    .ToArray();

        public string Encrypt(string textMessage, int textKey)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(textMessage) || textMessage.Contains(" "))
                {
                    MessageBox.Show("Шифр не может быть пустым или содержать пробелы");
                    return null;
                }

                char[] encryptedMessage = new char[textMessage.Length];

                for (int i = 0; i < textMessage.Length; i++)
                {
                    if (textMessage[i] != ' ')
                    {
                        encryptedMessage[i] = _russianAlphabet[(Array.IndexOf(_russianAlphabet, textMessage.ToUpper()[i]) + textKey) % 31];
                        textKey++;
                    }
                    else
                    {
                        encryptedMessage[i] = textMessage[i];
                    }
                }

                return new string(encryptedMessage);
            }
            catch
            {
                MessageBox.Show("Провеьте поля. Ключ должен быть целочисленным числом");
                return null;
            }
        }

        public string Decrypt(string textMessage, int textKey)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(textMessage) || textMessage.Contains(" "))
                {
                    MessageBox.Show("Шифр не может быть пустым или содержать пробелы");
                    return null;
                }

                char[] encryptedMessage = new char[textMessage.Length];

                for (int i = 0; i < textMessage.Length; i++)
                {
                    if (textMessage[i] != ' ')
                    {
                        encryptedMessage[i] = _russianAlphabet[(Array.IndexOf(_russianAlphabet, textMessage.ToUpper()[i]) - textKey + 31) % 31];
                        textKey++;
                    }
                    else
                    {
                        encryptedMessage[i] = textMessage[i];
                    }
                }

                return new string(encryptedMessage);
            }
            catch
            {
                MessageBox.Show("Провеьте поля. Ключ должен быть целочисленным числом");
                return null;
            }
        }
    }
}
