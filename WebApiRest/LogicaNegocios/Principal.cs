using LogicaNegocios.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocios
{
    public class Principal
    {
        //Listas
        public List<Movimiento> ListaMovimientos { get; set; }
        public List<UsuarioRecibe> ListaUsuariosRecibe { get; set; }
        public List<UsuarioEnvia> ListaUsuariosEnvia { get; set; }

        private readonly static Principal _principal = new Principal();

        public static Principal Instancia
        {
            get { return _principal; }
        }

        private Principal()
        {
            if (ListaMovimientos == null)
                ListaMovimientos = new List<Movimiento>();
            if (ListaUsuariosRecibe == null)
                ListaUsuariosRecibe = new List<UsuarioRecibe>();
            if (ListaUsuariosEnvia == null)
                ListaUsuariosEnvia = new List<UsuarioEnvia>();
        }

        public Resultado CargarMovimiento(Movimiento movimiento)
        {
            UsuarioEnvia usuarioEnvia = this.ValidarExistenciaUsuarioEnvia(movimiento.UsuarioEnvia.Dni);
            UsuarioRecibe usuarioRecibe = this.ValidarExistenciaUsuarioRecibe(movimiento.UsuarioRecibe.Dni);

            if (usuarioEnvia == null && usuarioRecibe == null)
            {
                return new Resultado(false, "Validacion usuario incorrecta.");
            }
            if (usuarioEnvia != null)
            {
                bool montoEnvio = ValidarMontoEnvio(movimiento.Monto, usuarioEnvia);

                if (montoEnvio)
                {
                    usuarioRecibe.Saldo += movimiento.Monto;
                    usuarioEnvia.Saldo -= movimiento.Monto;

                    movimiento.UsuarioEnvia = usuarioEnvia;
                    movimiento.UsuarioRecibe = usuarioRecibe;

                    movimiento.Descripcion = movimiento.Descripcion;
                    movimiento.UsuarioEnvia.ListaMovimientos.Add(movimiento);
                    movimiento.UsuarioRecibe.ListaMovimientos.Add(movimiento);

                    ListaMovimientos.Add(movimiento);

                }
                return new Resultado(true, "Carga correcta.");
            }
            return new Resultado(false, "Validacion incorrecta.");
        }

        public List<Movimiento> ObtenerListaMovimientos(int dni)
        {
            List<Movimiento> ListaFiltrada = ListaMovimientos;

            foreach (var usuario in ListaUsuariosEnvia)
            {
                if (usuario.Dni == dni)
                {
                    return ListaMovimientos.OrderBy(x => x.FechaMovimiento).ToList();
                }
            }
            foreach (var usuario in ListaUsuariosRecibe)
            {
                if (usuario.Dni == dni)
                {
                    return ListaMovimientos.OrderBy(x => x.FechaMovimiento).ToList();
                }
            }
            return ListaMovimientos;
        }

        public Resultado CancelarMovimiento(int idMovimiento)
        {
            foreach (var movimiento in ListaMovimientos)
            {
                if (movimiento.Id == idMovimiento)
                {
                    ListaMovimientos.Remove(movimiento);

                    return new Resultado(true, $"(El movimiento {movimiento.Id} fue cancelado.");
                }
            }
            return new Resultado(false, "Eliminacion incorrecta.");
        }

        private bool ValidarMontoEnvio(int monto, UsuarioEnvia usuarioEnvia)
        {
            if (monto <= usuarioEnvia.Saldo)
            {
                return true;
            }

            return false;
        }

        private UsuarioRecibe ValidarExistenciaUsuarioRecibe(int dni)
        {
            return ListaUsuariosRecibe.FirstOrDefault(x => x.Dni == dni);
        }

        private UsuarioEnvia ValidarExistenciaUsuarioEnvia(int dni)
        {
            return ListaUsuariosEnvia.FirstOrDefault(x => x.Dni == dni);
        }
    }
}
