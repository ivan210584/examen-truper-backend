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
    public class ClientesController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            RPClientes rpCli = new RPClientes();
            //return Ok(rpCli.ObtenerClientes());
            return Ok(rpCli.ObtenerUsuarios());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            RPClientes rpCli = new RPClientes();

            var cliRet = rpCli.ObtenerCliente(id);

            if (cliRet == null)
            {
                var nf = NotFound("El cliente " + id.ToString() + " no existe.");
                return nf;
            }

            return Ok(cliRet);
        }

        [HttpPost("agregar")]
        public IActionResult AgregarCliente(Clientes nuevoCliente)
        {
            RPClientes rpCli = new RPClientes();
            rpCli.Agregar(nuevoCliente);
            return CreatedAtAction(nameof(AgregarCliente), nuevoCliente);
        }

        [HttpPut("actualizar")]
        public IActionResult ActualizarCliente(Clientes clienteActualizar)
        {
            RPClientes rpCli = new RPClientes();
            rpCli.Actualizar(clienteActualizar);
            return Get();
        }

        [HttpDelete("{id}")]
        public IActionResult EliminarCliente(int id)
        {
            RPClientes rpCli = new RPClientes();
            rpCli.Eliminar(id);
            return Ok();
        }
    }
}
