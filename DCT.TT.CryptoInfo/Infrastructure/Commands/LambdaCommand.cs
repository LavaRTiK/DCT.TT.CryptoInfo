using DCT.TT.CryptoInfo.Infrastructure.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DCT.TT.CryptoInfo.Infrastructure.Commands
{
    internal class LambdaCommand : Command
    {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public LambdaCommand(Action Execute,Func<bool> CanExecute = null)
        :this(p => Execute(),CanExecute is null ? (Func<object,bool>)null : p => CanExecute())
        {

        }

        public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            _execute = Execute;
            _canExecute = CanExecute;
        }

        protected override bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true; 

        protected override void Execute(object parameter) => _execute(parameter); 
    }
}
