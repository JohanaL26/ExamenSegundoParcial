using Datos.Entidades;
using MySql.Data.MySqlClient;
using System;

namespace Datos.Accesos
{
    public class PedidosAccs
    {
        readonly string cadena = "Server=127.0.0.1; Port=3306; Database=segundoexamen; Uid=root; Pwd=JohaAdmin26;";
        MySqlConnection conn;
        MySqlCommand cmd;

        public int InsertarPedido(Pedidos pedidos)
        {
            int idPedidos = 0;
            try
            {
                string sql = "INSERT INTO pedidos (IdentidadCliente, Cliente, Fecha) VALUES (@IdentidadCliente, @Cliente, @Fecha); select last_insert_id();";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@IdentidadCliente", pedidos.IdentidadCliente);
                cmd.Parameters.AddWithValue("@Cliente", pedidos.Cliente);
                cmd.Parameters.AddWithValue("@Fecha", pedidos.Fecha);
                idPedidos = Convert.ToInt32(cmd.ExecuteScalar());


                conn.Close();
            }
            catch (Exception ex)
            {
            }
            return idPedidos;

        }

        public bool InsertarDetalle(DetallePedidos detallePedidos)
        {
            bool inserto = false;
            try
            {
                string sql = "INSERT INTO detallepedidos (IdPedidos, CodigoProducto, Descripcion, Cantidad, Precio, Total) VALUES (@IdPedidos, @CodigoProducto, @Descripcion, @Cantidad, @Precio, @Total);";

                conn = new MySqlConnection(cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@IdPedidos", detallePedidos.IdPedido);
                cmd.Parameters.AddWithValue("@CodigoProducto", detallePedidos.CodigoProducto);
                cmd.Parameters.AddWithValue("@Descripcion", detallePedidos.Descripcion);
                cmd.Parameters.AddWithValue("@Cantidad", detallePedidos.Cantidad);
                cmd.Parameters.AddWithValue("@Precio", detallePedidos.Precio);
                cmd.Parameters.AddWithValue("@Total", detallePedidos.Total);
                cmd.ExecuteNonQuery();

                inserto = true;
                conn.Close();
            }
            catch (Exception ex)
            {
            }
            return inserto;
        }









    }



}
