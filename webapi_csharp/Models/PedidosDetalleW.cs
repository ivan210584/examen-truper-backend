using System;
using System.Collections.Generic;

namespace webapi_csharp.Models
{
    public partial class PedidosDetalleW
    {
        public int Id { get; set; }
        public int? IdPedido { get; set; }
        public string Sku { get; set; }
        public double? Amout { get; set; }
        public double? Price { get; set; }

        public virtual PedidosW IdPedidoNavigation { get; set; }
        public virtual ProductoW SkuNavigation { get; set; }
    }
}
