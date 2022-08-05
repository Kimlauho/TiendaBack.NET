using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class ClienteModel
    {
        public int? idCliente { get; set; }
        public string cedula { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string telefono { get; set; }
        public int? estadoNota { get; set; }
        public string nota { get; set; }
    }
}
