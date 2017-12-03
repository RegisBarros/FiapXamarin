using System;
using System.Windows.Input;
using XF.LocalDB.Model;
using XF.LocalDB.ViewModel;

namespace XF.LocalDB.Commands
{
    public class OnAdicionarAlunoCMD : ICommand
    {
        private AlunoViewModel alunoVM;
        public OnAdicionarAlunoCMD(AlunoViewModel paramVM)
        {
            alunoVM = paramVM;
        }
        public event EventHandler CanExecuteChanged;
        public void AdicionarCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object parameter) => true;
        public void Execute(object parameter)
        {
            alunoVM.Adicionar(parameter as Aluno);
        }
    }
}
