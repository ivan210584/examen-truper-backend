using System;
using System.Collections.Generic;

namespace webapi_csharp.Models
{
    public partial class ProductoW
    {
        public ProductoW()
        {
            PedidosDetalleW = new HashSet<PedidosDetalleW>();
        }

        public string Sku { get; set; }
        public string Nombre { get; set; }
        public int Existencia { get; set; }
        public double Price { get; set; }

        public virtual ICollection<PedidosDetalleW> PedidosDetalleW { get; set; }
    }
}
