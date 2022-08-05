using BusinessRule;
using EntityModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WebAPI.Controllers
{
    [EnableCors("*","*","*")]
    public class VentaController : ApiController
    {
        [HttpGet]
        [Route("~/api/Venta/ObtenerVentas/{idClente}")]
        public IHttpActionResult ObtenerVentas(int idClente)
        {
            try
            {
                var result = VentaBR.ObtenerVentas(idClente);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("~/api/Venta/CrearEditarVenta")]
        public IHttpActionResult CrearEditarVenta(VentaModel Venta)
        {
            try
            {
                var result = VentaBR.CrearEditarVenta(Venta);
                if (result.estadoNota == 1)
                {
                    return BadRequest(result.nota);
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}