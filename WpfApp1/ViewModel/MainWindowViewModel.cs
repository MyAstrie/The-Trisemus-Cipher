using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.ViewModel
{
    internal class MainWindowViewModel : Base.ViewModel
    {
        #region Считывание текста для шифрования

        private string _encryptedString;

        /// <summary>
        /// Текст для шифрования
        /// </summary>
        public string EncryptedString
        {
            get => _encryptedString;
            set => Set(ref _encryptedString, value);
        }

        #endregion

        #region Считывание текста для дешифрования

        private string _decryptedString;

        /// <summary>
        /// Текст для дешифрования
        /// </summary>
        public string DecryptedString
        {
            get => _decryptedString;
            set => Set(ref _decryptedString, value);
        }

        #endregion

    }
}
