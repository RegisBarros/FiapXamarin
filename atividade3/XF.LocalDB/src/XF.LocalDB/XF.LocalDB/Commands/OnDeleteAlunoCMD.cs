using System;
using System.Windows.Input;
using XF.LocalDB.Model;
using XF.LocalDB.ViewModel;

namespace XF.LocalDB.Commands
{
    public class OnDeleteAlunoCMD : ICommand
    {
        private AlunoViewModel alunoVM;
        public OnDeleteAlunoCMD(AlunoViewModel paramVM)
        {
            alunoVM = paramVM;
        }
        public event EventHandler CanExecuteChanged;
        public void DeleteCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object parameter) => (parameter != null);
        public void Execute(object parameter)
        {
            App.AlunoVM.Selecionado = parameter as Aluno;
            alunoVM.Remover();
        }
    }
}
