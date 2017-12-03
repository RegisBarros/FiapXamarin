using Foundation;
using UIKit;
using XF.Contatos.App_Code;
using XF.Contatos.iOS.App_Code;

[assembly: Dependency(typeof(Telefone_Android))]
namespace XF.Contatos.iOS.App_Code
{
    public class Telefone_Android : ITelefone
    {
        public bool Ligar(string numero)
        {
            return UIApplication.SharedApplication.OpenUrl(
                new NSUrl("tel:" + numero));
        }
    }
}
