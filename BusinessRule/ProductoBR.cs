using DataModel.DataManager;
using EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRule
{
    public class ProductoBR
    {
        public static List<ProductoModel> ObtenerProductos()
        {
            return ProductoManager.ObtenerProductos();
        }

        public static ProductoModel CrearEditarProducto(ProductoModel producto)
        {
            return ProductoManager.CrearEditarProducto(producto);
        }
    }
}
