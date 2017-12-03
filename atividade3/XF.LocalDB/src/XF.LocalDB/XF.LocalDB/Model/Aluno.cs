using SQLite;

namespace XF.LocalDB.Model
{
    public class Aluno
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string RM { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool Aprovado { get; set; }
        public string IsAprovado
        {
            get
            {
                return (Aprovado) ? "Aprovado" : "Reprovado";
            }
        }
    }
}
