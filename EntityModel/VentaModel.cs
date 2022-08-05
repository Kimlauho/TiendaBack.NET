using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class VentaModel : ClienteModel
    {
        public int? idVenta { get; set; }
        public decimal? valorTotal { get; set; }
        public List<DetalleVentaModel> _DetalleVenta {get; set;}
    }

    public class DetalleVentaModel : ProductoModel
    {
        public int? idDetalleVenta { get; set; }
        public int? idVenta { get; set; }
    }
}
