using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integração_do_Visual_Studio_com_MYSQL
{
    public class Menu
    {
        private CadastroModel _cadastroModel = new CadastroModel();
        public int LegendaMenuPrincipal()
        {
            Console.WriteLine("1 = Cadastrar Usuario ou Coletor");
            Console.WriteLine("2 = Mostrar Usuarios e Coletores");
            Console.WriteLine("3 = Atualizar Cadastro de Usuarios ou Coletores");
            Console.WriteLine("4 = Excluir Cadastro");
            return Convert.ToInt32(Console.ReadLine());
        }
        public void MenuPrincipal()
        {
            switch (LegendaMenuPrincipal())
            {
                case 0:
                    break;
                case 1:

                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
            }
        }
    }
}
