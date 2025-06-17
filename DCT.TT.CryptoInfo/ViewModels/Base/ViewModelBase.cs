using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Markup;

namespace DCT.TT.CryptoInfo.ViewModels.Base
{
    internal abstract class ViewModelBase : MarkupExtension, INotifyPropertyChanged , IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
        protected virtual bool Set<T>(ref T field,T value, [CallerMemberName] string PropertyName = null)
        {
            if(Equals(field,value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
        private bool _Disposed;
        protected virtual void Dispose(bool Disposing)
        {
            if(!Disposing || _Disposed) return;
            _Disposed = true;
        }

        public override object ProvideValue(IServiceProvider sp)
        {
            return this;
        }
    }
}
