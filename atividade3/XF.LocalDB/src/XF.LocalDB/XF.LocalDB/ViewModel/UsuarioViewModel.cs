using System.Net.Http;
using XF.LocalDB.Commands;
using XF.LocalDB.Model;

namespace XF.LocalDB.ViewModel
{
    public class UsuarioViewModel
    {
        #region Propriedade
        public Usuario UsuarioModel { get; set; }
        public string Nome { get; set; }
        public string Stream { get; set; }

        // UI Events
        public IsAutenticarCMD IsAutenticarCMD { get; }
        #endregion

        public UsuarioViewModel()
        {
            UsuarioModel = new Usuario();
            IsAutenticarCMD = new IsAutenticarCMD(this);
            this.GetUsuarios("http://wopek.com/xml/usuarios.xml");
        }

        public void IsAutenticar(Usuario paramUser)
        {
            this.Nome = paramUser.Username;
            if (UsuarioRepository.IsAutorizado(paramUser))
                App.Current.MainPage.Navigation.PushAsync(
                    new View.Aluno.MainPage() { BindingContext = App.AlunoVM });
            else
                App.Current.MainPage.DisplayAlert("Atenção", "Usuário não autorizado", "Ok");
        }

        private async void GetUsuarios(string paramURL)
        {
            var httpRequest = new HttpClient();
            Stream = await httpRequest.GetStringAsync(paramURL);
        }
    }
}
