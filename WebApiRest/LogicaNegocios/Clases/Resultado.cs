using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios.Clases
{
    public class Resultado
    {
        public bool Estado { get; set; }
        public string Mensaje { get; set; }
        public string Id { get; set; }

        //201
        public Resultado(string id, bool ok)
        {
            this.Estado = ok;
            this.Id = id;
        }

        //400
        public Resultado(bool error, string mensaje)
        {
            this.Estado = error;
            this.Mensaje = mensaje;
        }

        public Resultado(bool ok)
        {
            this.Estado = ok;
        }

    }
}
