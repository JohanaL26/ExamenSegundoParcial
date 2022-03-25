using Datos.Entidades;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Accesos
{
    public class UsuarioAccs
    {
        //Se crea la cadena de conexión a la base de datos en MySql
        readonly string cadena = "Server=127.0.0.1; Port=3306; Database=segundoexamen; Uid=root; Pwd=JohaAdmin26;";

        //variables para la conexión
        MySqlConnection conn;
        MySqlCommand cmd;


        public Usuario Login(string codigo, string clave)
        {
            //declaracion de una variable usuario como nula
            Usuario user = null;

            try
            {
                //cadena de conexión a la tabla usuarios de mi base de datos
                string sql = "SELECT * FROM usuario WHERE Codigo=@Codigo AND Clave=@Clave;";

                conn = new MySqlConnection(cadena);
                conn.Open();//abre la conexión

                cmd = new MySqlCommand(sql, conn);
                //parámetros de la tabla necesarios para ingresar
                cmd.Parameters.AddWithValue("@Codigo", codigo);
                cmd.Parameters.AddWithValue("@Clave", clave);

                MySqlDataReader reader = cmd.ExecuteReader();

                //llamada de los datos de la tabla
                while (reader.Read())
                {
                    user = new Usuario();
                    user.Codigo = reader[0].ToString();
                    user.Nombre = reader[1].ToString();
                    user.Clave = reader[2].ToString();

                }
                reader.Close();
                conn.Close();//cierra conexión
               
                

            }
            catch (Exception ex)
            {
            }
            
            return user;

        }






    }





}
