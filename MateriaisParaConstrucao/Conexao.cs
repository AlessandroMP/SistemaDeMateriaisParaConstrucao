using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MateriaisParaConstrucao
{
    public class Conexao
    {
        //Atributo que é a String de conexão.
        private static string conexao = @"Data Source=.\SQLSERVER;Initial Catalog=Construcao;Persist Security Info=True;User ID=sa;Password=admin!@";

        //Metodo Acessor de leitura da String de conexao
        public static string StringConexao
        {
            get { return conexao; }
        }
    }
}
