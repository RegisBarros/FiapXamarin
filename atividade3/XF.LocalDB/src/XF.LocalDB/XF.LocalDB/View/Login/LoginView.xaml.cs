﻿
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XF.LocalDB.View.Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            txtUsuario.Text = pwdSenha.Text = string.Empty;
            base.OnAppearing();
        }
    }
}