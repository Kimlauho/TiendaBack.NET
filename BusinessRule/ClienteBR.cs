using DataModel.DataManager;
using EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessRule
{
    public class ClienteBR
    {
        public static ClienteModel ObtenerClientes(int idCliente)
        {
            return ClienteManager.ObtenerClientes(idCliente);
        }

        public static ClienteModel CrearEditarCliente(ClienteModel Cliente)
        {
            return ClienteManager.CrearEditarCliente(Cliente);
        }
    }
}
