using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webapi_csharp.Modelos;
using webapi_csharp.Models;
using webapi_csharp.Repositorios;

namespace webapi_csharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {

        [HttpGet]
        //[Authorize]
        public IActionResult Get()
        {
            RPPedidos rpPed = new RPPedidos();
            return Ok(rpPed.ObtenerPedidos());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            RPPedidos rpPed = new RPPedidos();

            var pedRet = rpPed.ObtenerPedido(id);

            if (pedRet == null)
            {
                var nf = NotFound("El pedido " + id.ToString() + " no existe.");
                return nf;
            }

            return Ok(pedRet);
        }

        [HttpPost("agregar")]
        [Authorize]
        public IActionResult AgregarPedido(DetallePedido detallePedido)
        {
            RPPedidos rpPed = new RPPedidos();
            rpPed.AgregarPedido(detallePedido);
            return CreatedAtAction(nameof(AgregarPedido), detallePedido);

            //return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarPedido(int id)
        {
            RPPedidos rpPed = new RPPedidos();
            rpPed.Eliminar(id);
            return Ok();
        }
    }
}
