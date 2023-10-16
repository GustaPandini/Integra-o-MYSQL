using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integração_do_Visual_Studio_com_MYSQL
{
    public class ColetorEntity
    {
        public int idColetor { get; set; }
        public string CPF { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public string Coleta { get; set; }
        public string Usuario_idUsuario { get; set; }
    }
}
