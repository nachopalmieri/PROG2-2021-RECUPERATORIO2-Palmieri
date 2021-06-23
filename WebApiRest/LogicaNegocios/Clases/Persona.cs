using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios.Clases
{
    public class Persona
    {
        public int Dni { get; set; }
        public int Nombre { get; set; }
        public int Apellido { get; set; }
        public int Saldo { get; set; }
        public List<Movimiento> ListaMovimientos { get; set; }
    }
}
