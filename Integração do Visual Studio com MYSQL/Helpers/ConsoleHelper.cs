using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integração_do_Visual_Studio_com_MYSQL.Helpers
{
    public class ConsoleHelper
    {
        public static string Pergunta_S_N(string mensagem)
        {
            Console.WriteLine(mensagem);
            return Console.ReadLine().ToUpper();
        }
    }
}
