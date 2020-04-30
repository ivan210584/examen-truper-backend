using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using webapi_csharp.Models;
using webapi_csharp.Repositorios;

namespace webapi_csharp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            RPProductos rpProd = new RPProductos();
            return Ok(rpProd.ObtenerProductos());
        }
    }
}
