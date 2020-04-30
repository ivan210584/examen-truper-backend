using System;
using System.Collections.Generic;
using System.Linq;
using webapi_csharp.Modelos;

using System.Data.SqlClient;
using System.Data;
using webapi_csharp.Models;

namespace webapi_csharp.Repositorios
{
    public class RPPedidos
    {

        public void Agregar(DetallePedido detallePedido)
        {
            bdpruebaContext context = new bdpruebaContext();

            //Guardar el encabezado del pedido y obtener el id para heredarlo al detalle del pedido
            PedidosW pedido = new PedidosW();
            pedido.Total = detallePedido.grantotal;
            pedido.DateSale = DateTime.Now.Date;
            pedido.Username = detallePedido.usuario;
            context.PedidosW.Add(pedido);
            context.SaveChanges();

            int idPedido = pedido.Id;

            //Por cada uno de los productos guardar su detalle en PedidosDetalleW
            foreach(DetalleProducto prod in detallePedido.detalleproductos)
            {
                PedidosDetalleW det = new PedidosDetalleW();
                det.IdPedido = idPedido;
                det.Sku = prod.sku;
                det.Amout = prod.cantidad;
                det.Price = prod.precioUnitario;
                context.PedidosDetalleW.Add(det);
                context.SaveChanges();
            }

        }

        public PedidosW ObtenerPedido(int id)
        {
            bdpruebaContext context = new bdpruebaContext();
            var pedido = context.PedidosW.Where(p => p.Id == id).FirstOrDefault();
            pedido.PedidosDetalleW = context.PedidosDetalleW.Where(d => d.IdPedido == id).ToList();
            return pedido;
        }

        public IEnumerable<PedidosW> ObtenerPedidos()
        {
            bdpruebaContext context = new bdpruebaContext();
            var pedidos = context.PedidosW;
            return pedidos;
        }

        public void AgregarPedido(DetallePedido detallePedido)
        {
            bdpruebaContext context = new bdpruebaContext();

            //Guardar el encabezado del pedido y obtener el id para heredarlo al detalle del pedido
            PedidosW pedido = new PedidosW();
            pedido.Total = detallePedido.grantotal;
            pedido.DateSale = DateTime.Now.Date;
            pedido.Username = detallePedido.usuario;
            context.PedidosW.Add(pedido);

            pedido.PedidosDetalleW = new List<PedidosDetalleW>();

            //Por cada uno de los productos guardar su detalle en PedidosDetalleW
            foreach (DetalleProducto prod in detallePedido.detalleproductos)
            {
                PedidosDetalleW det = new PedidosDetalleW();
                det.Sku = prod.sku;
                det.Amout = prod.cantidad;
                det.Price = prod.precioUnitario;
                context.PedidosDetalleW.Add(det);

                pedido.PedidosDetalleW.Add(det);
            }

            context.SaveChanges();

        }


        public void Eliminar(int idPedido)
        {
            bdpruebaContext context = new bdpruebaContext();

            //Eliminar de PedidosDetalleW
            var detallePedidoAEliminar = context.PedidosDetalleW.Where(d => d.IdPedido == idPedido);

            foreach(var det in detallePedidoAEliminar)
            {
                context.Remove(det);
            }
            
            //Eliminar de PedidosW
            var encabezadoPedidoAEliminar = context.PedidosW.Where(p => p.Id == idPedido).FirstOrDefault();
            context.Remove(encabezadoPedidoAEliminar);

            context.SaveChanges();
        }
    }
}
