using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XF.LocalDB.Model
{
    public class UsuarioRepository
    {
        private UsuarioRepository() { }

        private static readonly UsuarioRepository instance = new UsuarioRepository();
        public static UsuarioRepository Instance
        {
            get
            {
                return instance;
            }
        }

        public async Task<bool> IsAutorizado(string username, string password)
        {
            IEnumerable<Usuario> usuarios = await ObterUsuarios();

            return usuarios.Any(user => user.Username == username && user.Password == password);
        }

        private async Task<IEnumerable<Usuario>> ObterUsuarios()
        {
            var users = new List<Usuario>();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string response = await httpClient.GetStringAsync("http://wopek.com/xml/usuarios.xml");

                    if (!string.IsNullOrEmpty(response))
                    {
                        XElement xmlUsers = XElement.Parse(response);

                        foreach (var item in xmlUsers.Elements("usuario"))
                        {
                            var user = new Usuario()
                            {
                                Username = item.Element("username").Value,
                                Password = item.Element("password").Value
                            };

                            users.Add(user);
                        }
                    }
                }
            }
            catch
            {
                return ObterUsuariosInMemory();
            }

            return users;
        }

        private IEnumerable<Usuario> ObterUsuariosInMemory()
        {
            return new List<Usuario>()
            {
                new Usuario()
                {
                    Username = "admin",
                    Password = "admin"
                },
                new Usuario()
                {
                    Username = "aluno",
                    Password = "aluno"
                }
            };
        }
    }
}
