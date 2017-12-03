namespace XF.Contatos.Model
{
    public class Telefone
    {
        public Telefone() { }

        public PhoneType Tipo { get; set; }
        public string Descricao { get; set; }
        public string Numero { get; set; }
    }
}
