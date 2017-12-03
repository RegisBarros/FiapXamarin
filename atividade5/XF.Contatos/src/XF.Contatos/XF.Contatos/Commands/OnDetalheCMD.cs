using System;
using System.Windows.Input;
using XF.Contatos.Model;
using XF.Contatos.ViewModel;

namespace XF.Contatos.Commands
{
    public class OnDetalheCMD : ICommand
    {
        private ContatoViewModel contatoVM;
        public OnDetalheCMD(ContatoViewModel paramVM)
        {
            contatoVM = paramVM;
        }
        public event EventHandler CanExecuteChanged;
        public void DetalheCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object parameter)
        {
            if (parameter != null) return true;

            return false;
        }
        public void Execute(object parameter)
        {
            contatoVM.GetDetalhe(parameter as Contato);
        }
    }
}
