using System;
namespace webapi_csharp.Models
{
    public class DetalleProducto
    {
        public string sku { get; set; }
        public string producto { get; set; }
        public int cantidad { get; set; }
        public double precioUnitario { get; set; }
        public double total { get; set; }
    }
}
