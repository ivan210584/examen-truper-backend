using System;
using System.Collections.Generic;

namespace webapi_csharp.Models
{
    public class DetallePedido
    {
        public List<DetalleProducto> detalleproductos { get; set; }
        public double grantotal { get; set; }
        public string usuario { get; set; }
    }
}
