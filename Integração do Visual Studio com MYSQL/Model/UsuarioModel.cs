using Dapper;
using Integração_do_Visual_Studio_com_MYSQL.Helpers;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Integração_do_Visual_Studio_com_MYSQL.Entity;
using Integração_do_Visual_Studio_com_MYSQL.Model;

namespace Integração_do_Visual_Studio_com_MYSQL.Model
{
    internal class UsuarioModel : DataBase
    {
        public void Create()
        {
            UsuarioEntity cadastroUsuario = new UsuarioEntity();
            PopularNomeUsuario(cadastroUsuario);
            PopularSexo(cadastroUsuario);
            PopularIdade(cadastroUsuario);
            PopularTelefone(cadastroUsuario);
            PopularUsarioNoBanco(cadastroUsuario);
            string resp = ConsoleHelper.Pergunta_S_N("Deseja ser um Coletor? ( S/N )");
            if (resp == "S")
            {
                ColetorModel _coletorModel = new ColetorModel();
                _coletorModel.CadastrarNovoColetor();
            }
        }
        private int PopularUsarioNoBanco(UsuarioEntity cadastro)
        {
            using (MySqlConnection connection = new MySqlConnection(conectionString))
            {
                string sql = "INSERT INTO usuario VALUE (NULL, @NOME, @Sexo, @Idade, @Telefone)";
                return connection.Execute(sql, cadastro);
            }
        }

        private static void PopularTelefone(UsuarioEntity cadastro)
        {
            Console.WriteLine("Digite o seu Telfone");
            cadastro.Telefone = Console.ReadLine();
        }

        private static void PopularIdade(UsuarioEntity cadastro)
        {
            Console.WriteLine("Digite a sua Idade");
            cadastro.Idade = Convert.ToInt32(Console.ReadLine());
        }

        private static void PopularSexo(UsuarioEntity cadastro)
        {
            Console.WriteLine("Digite o seu Sexo");
            cadastro.Sexo = Console.ReadLine();
        }

        private static void PopularNomeUsuario(UsuarioEntity cadastro)
        {
            Console.WriteLine("Digite o seu Nome");
            cadastro.NOME = Console.ReadLine();
        }

        public void Delete()
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            Console.Clear();
            IEnumerable<UsuarioEntity> Usuarios = GetUsuario();
            foreach (UsuarioEntity Usuario in Usuarios)
            {
                pedido.Produtos = GetProdutoPedido(pedido.ID).ToList();
                Console.WriteLine(Usuario.NOME);
            }
        }
        public void PegarIDUsuario()
        {
            string sql = "SELECT * FROM usuario WHERE idUsuario = @ID";
            var parameters = new { ID = id };
            return this.GetConnection().QueryFirst<UsuarioEntity>(sql, parameters);
        }
        public IEnumerable<UsuarioEntity> GetUsuario()
        {
            string sql = "SELECT * FROM usuario";
            return this.GetConnection().Query<UsuarioEntity>(sql);
        }

        public void Update()
        {
            throw new NotImplementedException();
        }
    }
}
