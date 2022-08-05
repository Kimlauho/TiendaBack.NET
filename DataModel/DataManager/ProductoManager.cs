using EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DataManager
{
    public class ProductoManager
    {
        public static List<ProductoModel> ObtenerProductos()
        {
            try
            {
                using (TiendaEntities db = new TiendaEntities())
                {
                    return db.sp_obtenerProductos().AsEnumerable().Select(x => new ProductoModel()
                    {
                        idProducto = x.idProducto,
                        nombreProducto = x.nombreProducto,
                        valorUnitario = x.valorUnitario,
                        image = x.image
                    }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static ProductoModel CrearEditarProducto(ProductoModel Producto)
        {
            try
            {
                using (TiendaEntities db = new TiendaEntities())
                {
                    return db.sp_crearEditarProducto(Producto.idProducto, Producto.nombreProducto,Producto.valorUnitario, Producto.image).AsEnumerable().Select(x => new ProductoModel()
                    {
                        idProducto = x.idProducto,
                        nombreProducto = x.nombreProducto,
                        valorUnitario= x.valorUnitario,
                        image = x.image,
                        nota = x.nota,
                        estadoNota = x.estadoNota
                    }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
