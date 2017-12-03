using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using XF.Contatos.App_Code;
using XF.Contatos.Commands;
using XF.Contatos.Model;

namespace XF.Contatos.ViewModel
{
    public class ContatoViewModel : INotifyPropertyChanged
    {
        private Contato contato;
        public Contato Contato
        {
            get { return contato; }
            set
            {
                contato = value as Contato;
                OnLigarCMD.LigarCanExecuteChanged();
                EventPropertyChanged();
            }
        }
        public ObservableCollection<Contato> Contatos { get; set; } = new ObservableCollection<Contato>();

        // UI Events
        public OnLigarCMD OnLigarCMD { get; }
        public OnDetalheCMD OnDetalheCMD { get; }

        public ContatoViewModel()
        {
            OnLigarCMD = new OnLigarCMD(this);
            OnDetalheCMD = new OnDetalheCMD(this);
        }

        public async void Ligar(Contato paramContato)
        {
            if (!string.IsNullOrWhiteSpace(paramContato.Numero))
            {
                if (await App.Current.MainPage.DisplayAlert(
                    "Ligando...", "Ligar para " + paramContato.Numero + "?", "Sim", "Não"))
                {
                    var phone = DependencyService.Get<ITelefone>();
                    if (phone != null) phone.Ligar(paramContato.Numero);
                }
            }
        }

        public void GetDetalhe(Contato paramContato)
        {
            if (paramContato != null)
            {
                App.Current.MainPage.Navigation.PushAsync(
                    new View.DetalheView() { BindingContext = paramContato });
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void EventPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
