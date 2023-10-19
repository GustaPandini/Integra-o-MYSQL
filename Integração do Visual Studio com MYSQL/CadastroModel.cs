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
            Console.WriteLine("Digite o seu Sexo");
            cadastro.Sexo = Console.ReadLine();
            Console.WriteLine("Digite a sua Idade");
            cadastro.Idade = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Digite o seu Telfone");
            cadastro.Telefone = Console.ReadLine();

            using (MySqlConnection connection = new MySqlConnection(conectionString))
            {
                string sql = "INSERT INTO usuario VALUE (NULL, @NOME, @Sexo, @Idade, @Telefone)";
                int linhas = connection.Execute(sql, cadastro);
                Console.WriteLine($"Tipo inserido - {linhas} linhas afetadas");
            }

            Console.WriteLine("Deseja ser um Coletor de Residuos? ( S/N )");
            string resp1 = Console.ReadLine().ToUpper();
            if (resp1 == "S")
            {
                ColetorEntity coletor = new ColetorEntity();
                Console.WriteLine("O seu tipo de pessoa é Física (F) ou Juridica (J)?");
                string resp2 = Console.ReadLine().ToUpper();
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
                coletor.Usuario_idUsuario = 12;

                using (MySqlConnection connection = new MySqlConnection(conectionString))
                {
                    string sql = "INSERT INTO coletor VALUE (NULL, @CPF, @CNPJ, @Endereco, @Coleta, @Usuario_idUsuario)";
                    int linhas = connection.Execute(sql, coletor);
                    Console.WriteLine($"Tipo inserido - {linhas} linhas afetadas");
                }
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
