using Entity;
using System;
using System.Collections.Generic;
using Datos;

namespace Logica
{
    public class HabitacionService
    {
        private readonly ConnectionManager _conexion;
        private readonly HabitacionRepository _repositorio;
        public HabitacionService(string connectionString)
        {
            _conexion = new ConnectionManager(connectionString);
            _repositorio = new HabitacionRepository(_conexion);
        }

        public GuardarHabitacionResponse Guardar(Habitacion habitacion)
        {
            try
            {
                _conexion.Open();
                var habitacionx = _repositorio.BuscarPorIdentificacion(habitacion.IdHabitacion);
                if (habitacionx != null)
                {
                    return new GuardarHabitacionResponse("Error esta habitacion ya se encuentra registrada");
                }
                _repositorio.Guardar(habitacion);
                _conexion.Close();
                return new GuardarHabitacionResponse(habitacion);
            }
            catch (Exception e)
            {
                return new GuardarHabitacionResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }

        public List<Habitacion> ConsultarTodos()
        {
            _conexion.Open();
            List<Habitacion> habitaciones = _repositorio.ConsultarTodos();
            _conexion.Close();
            return habitaciones;
        }

        public string Eliminar(string identificacion)
        {
            try
            {
                _conexion.Open();
                var habitacion = _repositorio.BuscarPorIdentificacion(identificacion);
                if (habitacion != null)
                {
                    _repositorio.Eliminar(habitacion);
                    _conexion.Close();
                    return ($"El registro {habitacion.IdHabitacion} se ha eliminado satisfactoriamente.");
                }
                else
                {
                    return ($"Lo sentimos, {identificacion} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {
                return $"Error de la Aplicación: {e.Message}";
            }
            finally { _conexion.Close(); }

        }

        public ModificarHabitacionResponse Modificar(Habitacion habitacion)
        {            
            try
            {
                _conexion.Open();
                if (habitacion != null)
                {
                    _repositorio.Modificar(habitacion);
                    _conexion.Close();
                    return new ModificarHabitacionResponse(habitacion);
                }
                else
                {
                    return new ModificarHabitacionResponse($"Lo sentimos, {habitacion.IdHabitacion} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return new ModificarHabitacionResponse($"Error de la Aplicación: {e.Message}");
            }
            finally { _conexion.Close(); }
        }

        public Habitacion BuscarxIdentificacion(string identificacion)
        {
            _conexion.Open();
            Habitacion habitacion = _repositorio.BuscarPorIdentificacion(identificacion);
            _conexion.Close();
            return habitacion;
        }

        public class GuardarHabitacionResponse
        {
            public GuardarHabitacionResponse(Habitacion habitacion)
            {
                Error = false;
                Habitacion = habitacion;
            }
            public GuardarHabitacionResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Habitacion Habitacion { get; set; }
        }

        public class ModificarHabitacionResponse
        {
            public ModificarHabitacionResponse(Habitacion habitacion)
            {
                Error = false;
                Habitacion = habitacion;
            }
            public ModificarHabitacionResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Habitacion Habitacion { get; set; }
        }
    }
}