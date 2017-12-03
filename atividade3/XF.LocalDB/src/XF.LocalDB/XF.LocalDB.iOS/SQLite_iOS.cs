using System;
using System.IO;
using XF.LocalDB.Data;

namespace XF.LocalDB.iOS
{
    public class SQLite_iOS : IDependencyServiceSQLite
    {
        public SQLite_iOS()
        {

        }
        public SQLite.SQLiteConnection GetConexao()
        {
            var arquivodb = "fiapdb.db";
            string caminho = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string bibliotecaPessoal = Path.Combine(caminho, "..", "Library");
            var local = Path.Combine(bibliotecaPessoal, arquivodb);

            var conexao = new SQLite.SQLiteConnection(local);
            return conexao;
        }
    }
}
