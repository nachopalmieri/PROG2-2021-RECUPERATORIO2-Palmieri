using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LogicaNegocios;
using LogicaNegocios.Clases;
using WebApiRest.Models;

namespace WebApiRest.Controllers
{
    [RoutePrefix("api/movimientos")]
    public class MovimientoController : ApiController
    {
        Principal principal = Principal.Instancia;


        public IHttpActionResult Post([FromBody] MovimientoRequest request)
        {
            Movimiento movimiento = request.CrearMovimiento();
            Resultado resultado = principal.CargarMovimiento(movimiento);

            if (resultado.Estado)
            {
                return Content(HttpStatusCode.Created, resultado.Id);
            }
            return Content(HttpStatusCode.BadRequest, resultado);
        }

        [Route("{idMovimiento}")]
        public IHttpActionResult Delete([FromBody] int idMovimiento)
        {
            Resultado resultado = principal.CancelarMovimiento(idMovimiento);

            if (resultado.Estado)
            {
                return Content(HttpStatusCode.Created, resultado.Id);
            }
            return Content(HttpStatusCode.BadRequest, resultado);
        }


        public IHttpActionResult Get(int dni)
        {
            List<Movimiento> listaMovimientos = principal.ObtenerListaMovimientos(dni);
            List<MovimientoResponse> listado = MovimientoResponse.Conversor(listaMovimientos);

            if (listado != null)
            {
                return Content(HttpStatusCode.OK, listado);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, "No se encontro movimientos para estos usuarios.");
            }
        }
    }
}
