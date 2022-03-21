using System.Windows.Input;
using WpfApp1.infrastructure;

namespace WpfApp1.ViewModel
{
    internal class MainWindowViewModel : Base.ViewModel
    {
        #region EncryptedString

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

        #region EncryptedKeyString

        private string _encryptedKeyString;

        /// <summary>
        /// Ключ для шифрования
        /// </summary>
        public string EncryptedKeyString
        {
            get => _encryptedKeyString;
            set => Set(ref _encryptedKeyString, value);
        } 

        #endregion

        #region DecryptedString

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

        #region DecryptedKeyString

        private string _decryptedKeyString;

        /// <summary>
        /// Ключ для дешифрования
        /// </summary>
        public string DecryptedKeyString
        {
            get => _decryptedKeyString;
            set => Set(ref _decryptedKeyString, value);
        }

        #endregion

        #region EncryptedCommand

        public ICommand EncryptedCommand { get; private set; }

        private void OnEncryptedCommandExecuted(object p)
        {
            
        }

        private bool CanEncryptedCommandExecute(object p) => true;

        #endregion

        #region DecryptedCommand
        public ICommand DecryptedCommand { get; private set; }

        private void OnDecryptedCommandExecuted(object p)
        {

        }

        private bool CanDecryptedCommandExecute(object p) => true; 
        
        #endregion

        public MainWindowViewModel()
        {
            EncryptedCommand = new DelegateCommand(OnEncryptedCommandExecuted, CanEncryptedCommandExecute);
            DecryptedCommand = new DelegateCommand(OnDecryptedCommandExecuted, CanDecryptedCommandExecute);
        }
    }   
}