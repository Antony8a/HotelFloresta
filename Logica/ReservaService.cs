using Entity;
using System;
using System.Collections.Generic;
using Datos;

namespace Logica
{
    public class ReservaService
    {
        private readonly ConnectionManager _conexion;
        private readonly ReservaRepository _repositorio;
        public ReservaService(string connectionString)
        {
            _conexion = new ConnectionManager(connectionString);
            _repositorio = new ReservaRepository(_conexion);
        }

        public GuardarReservaResponse Guardar(Reserva reserva)
        {
            try
            {
                _conexion.Open();
                var reservax = _repositorio.BuscarPorIdentificacion(reserva.IdReserva);
                if (reservax != null)
                {
                    return new GuardarReservaResponse("Error esta reserva ya se encuentra registrado");
                }
                _repositorio.Guardar(reserva);
                _conexion.Close();
                return new GuardarReservaResponse(reserva);
            }
            catch (Exception e)
            {
                return new GuardarReservaResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }

        public List<Reserva> ConsultarTodos()
        {
            _conexion.Open();
            List<Reserva> reservas = _repositorio.ConsultarTodos();
            _conexion.Close();
            return reservas;
        }

        public int Eliminar(int identificacion)
        {
            try
            {
                _conexion.Open();
                var reserva = _repositorio.BuscarPorIdentificacion(identificacion);
                if (reserva != null)
                {
                    _repositorio.Eliminar(reserva);
                    _conexion.Close();
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception e)
            {
                return 2;
            }
            finally { _conexion.Close(); }

        }

        public ModificarReservaResponse Modificar(Reserva reserva)
        {            
            try
            {
                _conexion.Open();
                if (reserva != null)
                {
                    _repositorio.Modificar(reserva);
                    _conexion.Close();
                    return new ModificarReservaResponse(reserva);
                }
                else
                {
                    return new ModificarReservaResponse($"Lo sentimos, {reserva.IdReserva} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return new ModificarReservaResponse($"Error de la Aplicación: {e.Message}");
            }
            finally { _conexion.Close(); }
        }

        public Reserva BuscarxIdentificacion(int identificacion)
        {
            _conexion.Open();
            Reserva reserva = _repositorio.BuscarPorIdentificacion(identificacion);
            _conexion.Close();
            return reserva;
        }

        public class GuardarReservaResponse
        {
            public GuardarReservaResponse(Reserva reserva)
            {
                Error = false;
                Reserva = reserva;
            }
            public GuardarReservaResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Reserva Reserva { get; set; }
        }

        public class ModificarReservaResponse
        {
            public ModificarReservaResponse(Reserva reserva)
            {
                Error = false;
                Reserva = reserva;
            }
            public ModificarReservaResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Reserva Reserva { get; set; }
        }
    }
}