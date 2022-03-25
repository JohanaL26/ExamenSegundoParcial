using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class Productos
    {
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Existencia { get; set; }

        public Productos()
        {
        }

        public Productos(string codigo, string descripcion, decimal precio, int existencia)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Precio = precio;
            Existencia = existencia;
        }



    }
}
