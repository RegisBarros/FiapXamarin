using Android.App;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Geolocation;
using XF.Contatos.App_Code;
using XF.Contatos.Droid.App_Code;

[assembly: Dependency(typeof(Localizacao_Android))]
namespace XF.Contatos.Droid.App_Code
{
    public class Localizacao_Android : ILocalizacao
    {
        public void GetCoordenada()
        {
            var context = Forms.Context as Activity;
            var locator = new Geolocator(context) { DesiredAccuracy = 50 };
            locator.GetPositionAsync(timeout: 10000).ContinueWith(t => {
                SetCoordenada(t.Result.Latitude, t.Result.Longitude);
                System.Diagnostics.Debug.WriteLine(t.Result.Latitude);
            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        void SetCoordenada(double paramLatitude, double paramLongitude)
        {
            var coordenada = new Coordenada()
            {
                Latitude = paramLatitude.ToString(),
                Longitude = paramLongitude.ToString()
            };

            MessagingCenter.Send<ILocalizacao, Coordenada>(this, "coordenada", coordenada);
        }
    }
}