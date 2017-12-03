
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.AplicativoFiap.ViewModel;

namespace XF.AplicativoFiap.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfessorView : ContentPage
    {
        public ProfessorView()
        {
            BindingContext = ProfessorViewModel.Instancia;

            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            lstProfessores.IsRefreshing = !lstProfessores.IsRefreshing;
            await ProfessorViewModel.Instancia.Carregar();
            lstProfessores.IsRefreshing = !lstProfessores.IsRefreshing;
        }
    }
}