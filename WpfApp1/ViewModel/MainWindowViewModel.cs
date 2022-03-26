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

        private string _encryptionKey;

        /// <summary>
        /// Encryption key
        /// </summary>
        public string EncryptionKey
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

        private string _decryptionKey;

        /// <summary>
        /// Decryption key
        /// </summary>
        public string DecryptionKey
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

        #region EncryptionShift

        private int _encryptionShift;

        /// <summary>
        /// Shift for encryption
        /// </summary>
        public int EncryptionShift
        {
            get => _encryptionShift;
            set => Set(ref _encryptionShift, value);
        }

        #endregion

        #region DecryptionShift

        private int _decryptionShift;

        /// <summary>
        /// Shift for decryption
        /// </summary>
        public int DecryptionShift
        {
            get => _decryptionShift;
            set => Set(ref _decryptionShift, value);
        }

        #endregion

        #region EncryptionCommand

        public ICommand EncryptionCommand { get; private set; }

        private void OnEncryptionCommandExecuted(object p)
        {
            try
            {
                EncryptedString = TrithemiusCipher.Encrypt(EncryptionString, EncryptionKey, EncryptionShift);
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
                DecryptedString = TrithemiusCipher.Decrypt(DecryptionString, DecryptionKey, DecryptionShift);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private bool CanDecryptionCommandExecute(object p) => true; 
        
        #endregion

        private TrithemiusCipher TrithemiusCipher { get; }

        public MainWindowViewModel()
        {
            TrithemiusCipher = new TrithemiusCipher();
            EncryptionCommand = new DelegateCommand(OnEncryptionCommandExecuted, CanEncryptionCommandExecute);
            DecryptionCommand = new DelegateCommand(OnDecryptionCommandExecuted, CanDecryptionCommandExecute);
        }
    }
}