using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityModel
{
    public class ProductoModel
    {
        public int? idProducto {get; set;}
        public string nombreProducto {get; set;}
        public decimal? valorUnitario {get; set;}
        public string image {get; set;}
        public int? estadoNota {get; set;}
        public string nota { get; set;}
    }
}
