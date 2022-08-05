using EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel.DataManager
{
    public class ClienteManager
    {
        public static ClienteModel ObtenerClientes(int idCliente)
        {
            try
            {
                using (TiendaEntities db = new TiendaEntities())
                {
                    return db.sp_obtenerCliente(idCliente).AsEnumerable().Select(x => new ClienteModel()
                    {
                        idCliente = x.idCliente,
                        cedula = x.cedula,
                        nombre = x.nombre,
                        apellido = x.apellido,
                        telefono = x.telefono
                    }).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public static ClienteModel CrearEditarCliente(ClienteModel cliente)
        {
            try
            {
                using (TiendaEntities db = new TiendaEntities())
                {
                    return db.sp_crearEditarCliente(cliente.idCliente, cliente.cedula, cliente.nombre, cliente.apellido, cliente.telefono).AsEnumerable().Select(x => new ClienteModel()
                    {
                        idCliente = x.idCliente,
                        cedula = x.cedula,
                        nombre = x.nombre,
                        apellido = x.apellido,
                        telefono = x.telefono,
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
