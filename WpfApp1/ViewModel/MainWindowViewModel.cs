using System;
using System.Windows.Input;
using System.Windows;
using WpfApp1.infrastructure;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    internal class MainWindowViewModel : Base.ViewModel
    {
        #region EncryptionString

        private string _encryptionString;

        /// <summary>
        /// String for encryption
        /// </summary>
        public string EncryptionString
        {
            get => _encryptionString;
            set => Set(ref _encryptionString, value);
        }

        #endregion

        #region EncryptionKey

        private int _encryptionKey;

        /// <summary>
        /// Encryption key
        /// </summary>
        public int EncryptionKey
        {
            get => _encryptionKey;
            set => Set(ref _encryptionKey, value);
        }

        #endregion

        #region EncryptedString

        private string _encryptedString;

        /// <summary>
        /// String for encryption
        /// </summary>
        public string EncryptedString
        {
            get => _encryptedString;
            set => Set(ref _encryptedString, value);
        }

        #endregion

        #region DecryptionString

        private string _decryptionString;

        /// <summary>
        /// String for decryption
        /// </summary>
        public string DecryptionString
        {
            get => _decryptionString;
            set => Set(ref _decryptionString, value);
        }

        #endregion

        #region DecryptionKey

        private int _decryptionKey;

        /// <summary>
        /// Decryption key
        /// </summary>
        public int DecryptionKey
        {
            get => _decryptionKey;
            set => Set(ref _decryptionKey, value);
        }

        #endregion

        #region DecryptedSting

        private string _decryptedString;

        /// <summary>
        /// String for encryption
        /// </summary>
        public string DecryptedString
        {
            get => _decryptedString;
            set => Set(ref _decryptedString, value);
        }

        #endregion

        #region EncryptionCommand

        public ICommand EncryptionCommand { get; private set; }

        private void OnEncryptionCommandExecuted(object p)
        {
            try
            {
                EncryptedString = TrithemiusCipher.Encrypt(EncryptionString, EncryptionKey);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private bool CanEncryptionCommandExecute(object p) => true;

        #endregion

        #region DecryptionCommand

        public ICommand DecryptionCommand { get; private set; }

        private void OnDecryptionCommandExecuted(object p)
        {
            try
            {
                DecryptedString = TrithemiusCipher.Decrypt(DecryptionString, DecryptionKey);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private bool CanDecryptionCommandExecute(object p) => true; 
        
        #endregion

        private TrithemiusCipher _trithemiusCipher;

        private TrithemiusCipher TrithemiusCipher => _trithemiusCipher;

        public MainWindowViewModel()
        {
            _trithemiusCipher = new TrithemiusCipher();
            EncryptionCommand = new DelegateCommand(OnEncryptionCommandExecuted, CanEncryptionCommandExecute);
            DecryptionCommand = new DelegateCommand(OnDecryptionCommandExecuted, CanDecryptionCommandExecute);
        }
    }
}