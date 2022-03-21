using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfApp1.ViewModel.Base
{
    public abstract class ViewModel : INotifyPropertyChanged, IDisposable
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChangedEvent([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Checks if a property already matches a desired value

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            RaisePropertyChangedEvent(propertyName);
            return true;
        }

        #endregion

        #region Dispose Members

        // ~ViewModel()
        //{
        //    Dispose(false);
        //}

         public void Dispose()
         {
            Dispose(true);
         }

        private bool _disposed;

        protected virtual void Dispose(bool disposing)
        {
            if(!disposing || _disposed) return;
            _disposed = true;
            // Data release
        }

        #endregion
    }
}
