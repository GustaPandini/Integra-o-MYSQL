using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integração_do_Visual_Studio_com_MYSQL
{
    internal class CadastroModel : ICrud
    {
        public string conectionString = "Server=localhost;Database=testepi;User=root;Password=root;";
        public void Create()
        {
            UsuarioEntity cadastro = new UsuarioEntity();
            Console.WriteLine("Digite o seu Nome");
            cadastro.NOME = Console.ReadLine();

            using (MySqlConnection connection = new MySqlConnection(conectionString))
            {
                string sql = "INSERT INTO usuario VALUE (NULL, @NOME, @Sexo, @Idade, @Telefone)";
                int linhas = connection.Execute(sql, cadastro);
                Console.WriteLine($"Tipo inserido - {linhas} linhas afetadas");
            }
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Update()
        {
            throw new NotImplementedException();
        }

        private MySqlConnection GetConnection()
        {
            return new MySqlConnection(conectionString);
        }

        private int Execute(string sql, object obj)
        {
            using (MySqlConnection con = GetConnection())
            {
                return con.Execute(sql, obj);
            }
        }
    }
}
