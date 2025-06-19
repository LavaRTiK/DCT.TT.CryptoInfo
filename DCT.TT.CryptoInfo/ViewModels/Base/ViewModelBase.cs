using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Markup;
using System.Windows.Threading;

namespace DCT.TT.CryptoInfo.ViewModels.Base
{
    internal abstract class ViewModelBase : MarkupExtension, INotifyPropertyChanged , IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            var handlers = PropertyChanged;
            if(handlers is null) return;

            var invocationList = handlers.GetInvocationList();
            var arg = new PropertyChangedEventArgs(PropertyName);
            foreach (var arction in invocationList )
            {
                if (arction.Target is DispatcherObject dispatcherObject)
                    dispatcherObject.Dispatcher.Invoke(arction, this, arg);
                else
                    arction.DynamicInvoke(this, arg);
            }
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
