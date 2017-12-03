using System;
using System.Windows.Input;
using XF.Contatos.Model;
using XF.Contatos.ViewModel;

namespace XF.Contatos.Commands
{
    public class OnLigarCMD : ICommand
    {
        private ContatoViewModel contatoVM;
        public OnLigarCMD(ContatoViewModel paramVM)
        {
            contatoVM = paramVM;
        }
        public event EventHandler CanExecuteChanged;
        public void LigarCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object parameter)
        {
            if (parameter != null) return true;

            return false;
        }
        public void Execute(object parameter)
        {
            contatoVM.Ligar(parameter as Contato);
        }
    }
}
