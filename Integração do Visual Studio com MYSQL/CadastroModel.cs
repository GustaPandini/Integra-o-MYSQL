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
            PopularCadstroUsuario(cadastro);
            PopularUsarioNoBanco(cadastro);
            string resp = Pergunta_S_N("Deseja ser um Coletor? ( S/N )");
            if (resp == "S")
            {
                ColetorEntity coletor = new ColetorEntity();
                string resp2 = Pergunta_S_N("Pessoa Física (F) ou Juridica (J)?");
                if (resp2 == "F")
                {
                    Console.WriteLine("Digite seu CPF");
                    coletor.CPF = Console.ReadLine();
                }
                if (resp2 == "J")
                {
                    Console.WriteLine("Digite seu CNPJ");
                    coletor.CNPJ = Console.ReadLine();
                }
                Console.WriteLine("Digite o seu Endereco");
                coletor.Endereco = Console.ReadLine();
                Console.WriteLine("Digite a sua forma de Coleta");
                coletor.Coleta = Console.ReadLine();
                using (MySqlConnection connection = new MySqlConnection(conectionString))
                {
                    string sql = "SELECT * FROM usuario ORDER BY idUsuario DESC LIMIT 1";
                    coletor.Usuario_idUsuario = this.GetConnection().QueryFirst<UsuarioEntity>(sql).idUsuario;
                }

                using (MySqlConnection connection = new MySqlConnection(conectionString))
                {
                    string sql = "INSERT INTO coletor VALUE (NULL, @CPF, @CNPJ, @Endereco, @Coleta, @Usuario_idUsuario)";
                    int linhas = connection.Execute(sql, coletor);
                    Console.WriteLine($"Tipo inserido - {linhas} linhas afetadas");
                }
            }
        }

        private static string Pergunta_S_N(string mensagem)
        {
            Console.WriteLine(mensagem);
            return Console.ReadLine().ToUpper();
        }

        private int PopularUsarioNoBanco(UsuarioEntity cadastro)
        {
            using (MySqlConnection connection = new MySqlConnection(conectionString))
            {
                string sql = "INSERT INTO usuario VALUE (NULL, @NOME, @Sexo, @Idade, @Telefone)";
                return connection.Execute(sql, cadastro);
            }
        }

        private static void PopularCadstroUsuario(UsuarioEntity cadastro)
        {
            Console.WriteLine("Digite o seu Nome");
            cadastro.NOME = Console.ReadLine();
            Console.WriteLine("Digite o seu Sexo");
            cadastro.Sexo = Console.ReadLine();
            Console.WriteLine("Digite a sua Idade");
            cadastro.Idade = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o seu Telfone");
            cadastro.Telefone = Console.ReadLine();
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
