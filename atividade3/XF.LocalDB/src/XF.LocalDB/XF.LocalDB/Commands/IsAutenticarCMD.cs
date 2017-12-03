using System;
using System.Windows.Input;
using XF.LocalDB.Model;
using XF.LocalDB.ViewModel;

namespace XF.LocalDB.Commands
{
    public class IsAutenticarCMD : ICommand
    {
        private UsuarioViewModel usuarioVM;
        public IsAutenticarCMD(UsuarioViewModel paramVM)
        {
            usuarioVM = paramVM;
        }
        public event EventHandler CanExecuteChanged;
        public void DeleteCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object parameter)
        {
            if (parameter != null) return true;

            return false;
        }
        public void Execute(object parameter)
        {
            usuarioVM.IsAutenticar(parameter as Usuario);
        }
    }
}
