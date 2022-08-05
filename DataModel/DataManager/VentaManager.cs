using EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DataManager
{
    public class VentaManager
    {
        public static List<VentaModel> ObtenerVentas(int idClente)
        {
            try
            {
                using (TiendaEntities db = new TiendaEntities())
                {
                    return db.sp_obtenerVentas(idClente).AsEnumerable().Select(x => new VentaModel()
                    {
                        idVenta = x.idVenta,
                        idCliente = x.idCliente,
                        nombre = x.nombre,
                        apellido = x.apellido,
                        valorTotal = x.valorTotal,
                        _DetalleVenta = db.sp_obtenerDetalleVentas(x.idVenta).AsEnumerable().Select(z => new DetalleVentaModel()
                        {
                            idVenta = x.idVenta,
                            idDetalleVenta = z.idDetalleVenta,
                            idProducto = z.idProducto,
                            nombreProducto = z.nombreProducto,
                            valorUnitario = z.valorUnitario
                        }).ToList()
                }).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public static VentaModel CrearEditarVenta(VentaModel Venta)
        {
            try
            {
                VentaModel ventaResult = new VentaModel();
                using (TiendaEntities db = new TiendaEntities())
                {
                    ventaResult = db.sp_crearEditarVenta(Venta.idVenta, Venta.idCliente, Venta.valorTotal).AsEnumerable().Select(x => new VentaModel()
                    {
                        idVenta = x.idVenta,
                        idCliente = x.idCliente,
                        valorTotal = x.valorTotal,
                        nota = x.nota,
                        estadoNota = x.estadoNota
                    }).FirstOrDefault();

                    if (ventaResult.estadoNota == 1)
                    {
                        return ventaResult;
                    }

                    if (ventaResult.idVenta != null && Venta._DetalleVenta != null)
                    {
                        List<DetalleVentaModel> listDetalle = new List<DetalleVentaModel>();
                        foreach (var item in Venta._DetalleVenta)
                        {
                            DetalleVentaModel detalle = new DetalleVentaModel();
                            detalle = db.sp_crearEditarDetalleVenta(ventaResult.idVenta,item.idDetalleVenta, item.idProducto, item.valorUnitario).AsEnumerable().Select(x => new DetalleVentaModel()
                            {
                                idVenta = x.idVenta,
                                idDetalleVenta = x.idDetalleVenta,
                                idProducto = x.idProducto,
                                valorUnitario = x.valorUnitario,
                                nota = x.nota,
                                estadoNota = x.estadoNota
                            }).FirstOrDefault();
                            listDetalle.Add(detalle);

                            if (detalle.estadoNota == 1)
                            {
                                ventaResult._DetalleVenta = listDetalle;
                                ventaResult.nota = detalle.nota;
                                ventaResult.estadoNota = 1;
                                return ventaResult;
                            }
                        }
                        ventaResult._DetalleVenta = listDetalle;
                    }
                }
                return ventaResult;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
