using System;
using System.Collections.Generic;

namespace webapi_csharp.Models
{
    public partial class PedidosW
    {
        public PedidosW()
        {
            PedidosDetalleW = new HashSet<PedidosDetalleW>();
        }

        public int Id { get; set; }
        public double? Total { get; set; }
        public DateTime? DateSale { get; set; }
        public string Username { get; set; }

        public virtual UsuariosW UsernameNavigation { get; set; }
        public virtual ICollection<PedidosDetalleW> PedidosDetalleW { get; set; }
    }
}
