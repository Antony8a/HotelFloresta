using Entity;
using System;
using System.Collections.Generic;
using Datos;

namespace Logica
{
    public class RecepcionistaService
    {
        private readonly ConnectionManager _conexion;
        private readonly RecepcionistaRepository _repositorio;
        public RecepcionistaService(string connectionString)
        {
            _conexion = new ConnectionManager(connectionString);
            _repositorio = new RecepcionistaRepository(_conexion);
        }

        public GuardarRecepcionistaResponse Guardar(Recepcionista recepcionista)
        {
            try
            {
                _conexion.Open();
                var recepcionistax = _repositorio.BuscarPorIdentificacion(recepcionista.Identificacion);
                if (recepcionistax != null)
                {
                    return new GuardarRecepcionistaResponse("Error, la recepcionista ya se encuentra registrada");
                }
                _repositorio.Guardar(recepcionista);
                _conexion.Close();
                return new GuardarRecepcionistaResponse(recepcionista);
            }
            catch (Exception e)
            {
                return new GuardarRecepcionistaResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }

        public List<Recepcionista> ConsultarTodos()
        {
            _conexion.Open();
            List<Recepcionista> Recepcionistas = _repositorio.ConsultarTodos();
            _conexion.Close();
            return Recepcionistas;
        }

        public string Eliminar(string identificacion)
        {
            try
            {
                _conexion.Open();
                var recepcionista = _repositorio.BuscarPorIdentificacion(identificacion);
                if (recepcionista != null)
                {
                    _repositorio.Eliminar(recepcionista);
                    _conexion.Close();
                    return ($"El registro {recepcionista.Nombre} se ha eliminado satisfactoriamente.");
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

        public ModificarRecepcionistaResponse ModificarRecepcionista(Recepcionista recepcionista)
        {            
            try
            {
                _conexion.Open();
                if (recepcionista != null)
                {
                    _repositorio.Modificar(recepcionista);
                    _conexion.Close();
                    return new ModificarRecepcionistaResponse(recepcionista);
                }
                else
                {
                    return new ModificarRecepcionistaResponse($"Lo sentimos, {recepcionista.Identificacion} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return new ModificarRecepcionistaResponse($"Error de la Aplicación: {e.Message}");
            }
            finally { _conexion.Close(); }
        }

        public Recepcionista BuscarxIdentificacion(string identificacion)
        {
            _conexion.Open();
            Recepcionista recepcionista = _repositorio.BuscarPorIdentificacion(identificacion);
            _conexion.Close();
            return recepcionista;
        }

        public class GuardarRecepcionistaResponse
        {
            public GuardarRecepcionistaResponse(Recepcionista recepcionista)
            {
                Error = false;
                Recepcionista = recepcionista;
            }
            public GuardarRecepcionistaResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Recepcionista Recepcionista { get; set; }
        }

        public class ModificarRecepcionistaResponse
        {
            public ModificarRecepcionistaResponse(Recepcionista recepcionista)
            {
                Error = false;
                Recepcionista = recepcionista;
            }
            public ModificarRecepcionistaResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Recepcionista Recepcionista { get; set; }
        }
    }
}