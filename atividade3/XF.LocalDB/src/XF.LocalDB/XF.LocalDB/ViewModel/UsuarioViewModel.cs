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

        public IsAutenticarCMD IsAutenticarCMD { get; }

        public UsuarioRepository UsuarioRepository => UsuarioRepository.Instance;
        #endregion

        public UsuarioViewModel()
        {
            UsuarioModel = new Usuario();
            IsAutenticarCMD = new IsAutenticarCMD(this);
        }

        public async void IsAutenticar(Usuario usuario)
        {
            this.Nome = usuario.Username;
            if (await UsuarioRepository.IsAutorizado(usuario.Username, usuario.Password))
                await App.Current.MainPage.Navigation.PushAsync(
                    new View.Aluno.MainPage() { BindingContext = App.AlunoVM });
            else
                await App.Current.MainPage.DisplayAlert("Atenção", "Usuário não autorizado", "Ok");
        }
       
    }
}
