using LogicaNegocios.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiRest.Models
{
    public class MovimientoRequest
    {
        public int DniRecibe { get; set; }
        public int DniEnvia { get; set; }
        public string Descripcion { get; set; }
        public int MontoAEnviar { get; set; }

        public Movimiento CrearMovimiento()
        {
            Movimiento movimiento = new Movimiento(this.DniRecibe, this.DniEnvia, this.Descripcion, this.MontoAEnviar);
            return movimiento;
        }
    }
}