using System;
using System.Collections.Generic;
using System.Linq;
using webapi_csharp.Modelos;

using System.Data.SqlClient;
using System.Data;
using webapi_csharp.Models;

namespace webapi_csharp.Repositorios
{
    public class RPClientes
    {
        public static List<Cliente> _listaClientes = new List<Cliente>();
        
        /*
        {
            new Cliente() { Id = 1, Nombre = "Cliente 1" , Apellido = "Apellido 1" },
            new Cliente() { Id = 2, Nombre = "Cliente 2" , Apellido = "Apellido 2" },
            new Cliente() { Id = 3, Nombre = "Cliente 3" , Apellido = "Apellido 3" }
        };*/

        public IEnumerable<Clientes> ObtenerClientes()
        {
            _listaClientes = new List<Cliente>();
            //ConectarABaseDeDatos();
            return ConectarPorEF();
            //return _listaClientes;
        }

        public IEnumerable<Usuarios> ObtenerUsuarios()
        {
            _listaClientes = new List<Cliente>();
            //ConectarABaseDeDatos();
            return ConectarPorEFUsuarios();
            //return _listaClientes;
        }

        private IEnumerable<Clientes> ConectarPorEF()
        {
            bdpruebaContext context = new bdpruebaContext();
            var table = context.Clientes;
            var table2 = context.Usuarios;
            return table;
        }

        private IEnumerable<Usuarios> ConectarPorEFUsuarios()
        {
            bdpruebaContext context = new bdpruebaContext();
            var table2 = context.Usuarios;
            return table2;
        }

        private void ConectarABaseDeDatos()
        {
            /*
            SqlConnection conexion = new SqlConnection("server=rierdb.cbfhwdzfoyqc.us-east-2.rds.amazonaws.com ; database=bdprueba ; user id = admin; password = J1m12159");
            conexion.Open();
            conexion.Close();
            */


            string connString = "server=rierdb.cbfhwdzfoyqc.us-east-2.rds.amazonaws.com ; database=bdprueba ; user id = admin; password = J1m12159";
            string query = "select * from guest.Clientes";

            SqlConnection conn = new SqlConnection(connString);
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();

            // create data adapter
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            // this will query your database and return the result to your datatable
            da.Fill(dataTable);


            //Recorrer el datatable
            foreach(DataRow dr in dataTable.Rows)
            {
                int id = Convert.ToInt32(dr[0]);
                string nombre = Convert.ToString(dr[1]);
                string apellido = Convert.ToString(dr[2]);

                Cliente c = new Cliente();
                c.Id = id;
                c.Apellido = apellido;
                c.Nombre = nombre;

                _listaClientes.Add(c);
            }



            conn.Close();
            da.Dispose();
        }

        public Clientes ObtenerCliente(int id)
        {
            /*
            var cliente = _listaClientes.Where(cli => cli.Id == id);
            return cliente.FirstOrDefault();
            */
            bdpruebaContext context = new bdpruebaContext();
            var cliente = context.Clientes.Where(c=>c.Id==id).FirstOrDefault();
            return cliente;
        }

        public void Agregar(Clientes nuevoCliente)
        {
            //_listaClientes.Add(nuevoCliente);
            bdpruebaContext context = new bdpruebaContext();
            context.Clientes.Add(nuevoCliente);
            context.SaveChanges();
        }

        public void Actualizar(Clientes clienteActualizar)
        {
            //Eliminar(clienteActualizar.Id);
            //Agregar(clienteActualizar);

            //Con update
            bdpruebaContext context = new bdpruebaContext();
            var cteUpdate = context.Clientes.Where(c => c.Id == clienteActualizar.Id).FirstOrDefault();
            cteUpdate.Nombre = clienteActualizar.Nombre;
            cteUpdate.Apellido = clienteActualizar.Apellido;
            context.SaveChanges();

        }

        public void Eliminar(int id)
        {
            /*
            var cliente = _listaClientes.Where(cli => cli.Id == id);
            _listaClientes.Remove(cliente.FirstOrDefault());
            */

            bdpruebaContext context = new bdpruebaContext();
            var clienteAEliminar = context.Clientes.Where(c => c.Id == id).FirstOrDefault();
            context.Remove(clienteAEliminar);
            context.SaveChanges();
        }
    }
}
