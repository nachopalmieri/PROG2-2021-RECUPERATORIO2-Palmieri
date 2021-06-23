using LogicaNegocios.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiRest.Models
{
    public class MovimientoResponse
    {
        public int Id { get; set; }
        public DateTime FechaMovimiento { get; set; }
        public string Descripcion { get; set; }
        public int Monto { get; set; }
        public UsuarioEnvia UsuarioEnvia { get; set; }
        public UsuarioRecibe UsuarioRecibe { get; set; }

        public MovimientoResponse(Movimiento movimiento)
        {
            this.Id = Id;
            this.FechaMovimiento = FechaMovimiento;
            this.Descripcion = Descripcion;
            this.Monto = Monto;
            this.UsuarioEnvia = UsuarioEnvia;
            this.UsuarioRecibe = UsuarioRecibe;

        }
        public static List<MovimientoResponse> Conversor(List<Movimiento> listaMovimientos)
        {
            List<MovimientoResponse> movimientoResponse = new List<MovimientoResponse>();
            foreach (var movimiento in listaMovimientos)
            {
                MovimientoResponse movimientos = new MovimientoResponse(movimiento);
                movimientoResponse.Add(movimientos);
            }
            return movimientoResponse;
        }
    }
}