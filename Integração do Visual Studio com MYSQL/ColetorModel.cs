using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integração_do_Visual_Studio_com_MYSQL
{
    public class ColetorModel : DataBase
    {
        private void CadastrarNovoColetor(ColetorEntity coletor)
        {
            string resp3 = ConsoleHelper.Pergunta_S_N("Pessoa Física (F) ou Juridica (J)?");
            if (resp3 == "F")
            {
                CadastrarCPF(coletor);
            }
            if (resp3 == "J")
            {
                CadastrarCNPJ(coletor);
            }
            CadastrarEndereco(coletor);
            CadastrarFormaColeta(coletor);
            PegarUltimoIDUsuario(coletor);
            PopularColetorNoBanco(coletor);
        }
        private void CadastrarCPF(ColetorEntity coletor)
        {
            Console.WriteLine("Digite seu CPF");
            coletor.CPF = Console.ReadLine();
        }
        private void CadastrarCNPJ(ColetorEntity coletor)
        {
            Console.WriteLine("Digite seu CNPJ");
            coletor.CNPJ = Console.ReadLine();
        }
        private static void CadastrarEndereco(ColetorEntity coletor)
        {
            Console.WriteLine("Digite o seu Endereco");
            coletor.Endereco = Console.ReadLine();
        }
        private static void CadastrarFormaColeta(ColetorEntity coletor)
        {
            Console.WriteLine("Digite a sua forma de Coleta");
            coletor.Coleta = Console.ReadLine();
        }
        private void PegarUltimoIDUsuario(ColetorEntity coletor)
        {
            using (MySqlConnection connection = new MySqlConnection(conectionString))
            {
                string sql = "SELECT * FROM usuario ORDER BY idUsuario DESC LIMIT 1";
                coletor.Usuario_idUsuario = this.GetConnection().QueryFirst<UsuarioEntity>(sql).idUsuario;
            }
        }
        private void PopularColetorNoBanco(ColetorEntity coletor)
        {
            using (MySqlConnection connection = new MySqlConnection(conectionString))
            {
                string sql = "INSERT INTO coletor VALUE (NULL, @CPF, @CNPJ, @Endereco, @Coleta, @Usuario_idUsuario)";
                int linhas = connection.Execute(sql, coletor);
                Console.WriteLine($"Tipo inserido - {linhas} linhas afetadas");
            }
        }
       
    }
}
