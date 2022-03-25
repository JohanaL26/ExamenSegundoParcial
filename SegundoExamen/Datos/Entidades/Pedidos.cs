using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class Pedidos
    {
        public int Id { get; set; }
        public string IdentidadCliente { get; set; }
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }

        public Pedidos()
        {
        }

        public Pedidos(int id, string identidadCliente, string cliente, DateTime fecha)
        {
            Id = id;
            IdentidadCliente = identidadCliente;
            Cliente = cliente;
            Fecha = fecha;
        }


    }
}
