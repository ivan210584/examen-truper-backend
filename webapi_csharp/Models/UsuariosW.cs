using System;
using System.Collections.Generic;

namespace webapi_csharp.Models
{
    public partial class UsuariosW
    {
        public UsuariosW()
        {
            PedidosW = new HashSet<PedidosW>();
        }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        public virtual ICollection<PedidosW> PedidosW { get; set; }
    }
}
