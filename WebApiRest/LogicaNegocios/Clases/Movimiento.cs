using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios.Clases
{
    public class Movimiento
    {
        public int Id { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string Descripcion { get; set; }
        public int Monto { get; set; }
        public UsuarioEnvia UsuarioEnvia { get; set; }
        public UsuarioRecibe UsuarioRecibe { get; set; }

        public Movimiento(int dniRecibe, int dniEnvia, string descripcion, int montoAEnviar)
        {
            this.UsuarioEnvia.Dni = dniRecibe;
            this.UsuarioRecibe.Dni = dniEnvia;
            this.Descripcion = descripcion;
            this.Monto = montoAEnviar;
        }
    }
}
