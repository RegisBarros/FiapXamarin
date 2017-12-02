using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace XF.Hello
{
    public class Email: INotifyPropertyChanged
    {
        private string _conta;

        public string Conta
        {
            get
            {
                return _conta;
            }
            set
            {
                _conta = value;
                EventPropertyChanged();
            }
        }

        private bool _aceitaEnvio;
        public bool AceitaEnvio
        {
            get
            {
                return _aceitaEnvio;
            }
            set
            {
                _aceitaEnvio = value;

                if (!_aceitaEnvio)
                    Conta = string.Empty;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void EventPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
