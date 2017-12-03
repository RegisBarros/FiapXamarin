using System;
using System.Windows.Input;
using XF.AplicativoFiap.Model;
using XF.AplicativoFiap.ViewModel;

namespace XF.AplicativoFiap.Commands
{
    public class OnEditarProfessorCMD : ICommand
    {
        private ProfessorViewModel professorVM;
        public OnEditarProfessorCMD(ProfessorViewModel paramVM)
        {
            professorVM = paramVM;
        }
        public event EventHandler CanExecuteChanged;
        public void EditarCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public bool CanExecute(object parameter) => (parameter != null);
        public void Execute(object parameter)
        {
            ProfessorViewModel.Instancia.Selecionado = parameter as Professor;
            professorVM.Editar();
        }
    }
}
