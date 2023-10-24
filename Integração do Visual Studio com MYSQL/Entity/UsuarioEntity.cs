using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integração_do_Visual_Studio_com_MYSQL.Entity
{
    public class UsuarioEntity
    {
        public int idUsuario { get; set; }
        public string NOME { get; set; }
        public string Sexo { get; set; }
        public int Idade { get; set; }
        public string Telefone { get; set; }
    }
}
