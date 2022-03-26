using System;
using System.Linq;
using System.Windows;

namespace WpfApp1.Model
{
    internal class TrithemiusCipher
    {
        char[] _alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ ,.?!'<>/;[]=-".ToCharArray();

        public string Encrypt(string textMessage, string textKey, int shift)
        {
            try
            {
                if (string.IsNullOrEmpty(textMessage) || string.IsNullOrEmpty(textKey))
                    return null;

                var keyword = textKey.ToUpper().Distinct().ToArray();

                var cipherAlphabet = new char[_alphabet.Length];

                keyword.CopyTo(cipherAlphabet, 0);

                _alphabet.Except(keyword).ToArray().CopyTo(cipherAlphabet, keyword.Length);

                var text = textMessage.ToUpper().ToArray();

                // преобразует список символов исходного текста в список индексов этих символов в алфавите
                // преобразует список индексов символов исходного текста в символы шифротекста согласно заданному смещению
                var encryptedMessage = text.Select(c => Array.IndexOf(cipherAlphabet, c))      
                                       .Select(index => index + shift < cipherAlphabet.Length 
                                           ? cipherAlphabet[index + shift] 
                                           : cipherAlphabet[index - _alphabet.Length])
                                       .ToArray();

                return new string(encryptedMessage);
            }
            catch
            {
                MessageBox.Show("Провеьте поля. Ключ должен быть целочисленным числом");
                return null;
            }
        }

        public string Decrypt(string textMessage, string textKey, int shift)
        {
            try
            {
                if (string.IsNullOrEmpty(textMessage) || string.IsNullOrEmpty(textKey))
                    return null;

                var keyword = textKey.ToUpper().Distinct().ToArray();

                var cipherAlphabet = new char[_alphabet.Length];

                keyword.CopyTo(cipherAlphabet, 0);

                _alphabet.Except(keyword).ToArray().CopyTo(cipherAlphabet, keyword.Length);

                var text = textMessage.ToUpper().ToArray();

                var decriptedMessage = text.Select(c => Array.IndexOf(cipherAlphabet, c))
                    .Select(index => index - shift >= 0 
                        ? cipherAlphabet[index - shift] 
                        : cipherAlphabet[index + _alphabet.Length])
                    .ToArray();

                return new string(decriptedMessage);
            }
            catch
            {
                MessageBox.Show("Провеьте поля. Ключ должен быть целочисленным числом");
                return null;
            }
        }
    }
}
