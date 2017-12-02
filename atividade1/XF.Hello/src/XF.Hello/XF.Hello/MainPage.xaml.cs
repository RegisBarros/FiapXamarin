using System;
using Xamarin.Forms;

namespace XF.Hello
{
    public partial class MainPage : ContentPage
    {
        Email Email;
        public MainPage()
        {
            InitializeComponent();

            Email = new Email();
        }

        private void EnviarEmail_Clicked(object sender, EventArgs e)
        {
            if (Email.AceitaEnvio && !string.IsNullOrEmpty(Email.Conta))
            {
                DisplayAlert("Mensagem", $"E-mail enviado para {Email.Conta}", "OK");
            }
            else
            {
                DisplayAlert("Mensagem", $"E-mail não autorizado", "OK");  
            }
       
        }

        private void Configuracao_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ConfigPage() { BindingContext = Email });
        }
    }
}
