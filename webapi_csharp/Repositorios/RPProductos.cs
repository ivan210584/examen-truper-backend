using System;
using System.Collections.Generic;
using System.Linq;
using webapi_csharp.Modelos;

using System.Data.SqlClient;
using System.Data;
using webapi_csharp.Models;

namespace webapi_csharp.Repositorios
{
    public class RPProductos
    {
        public IEnumerable<ProductoW> ObtenerProductos()
        {
            bdpruebaContext context = new bdpruebaContext();
            var table = context.ProductoW;
            return table;
        }
    }
}
