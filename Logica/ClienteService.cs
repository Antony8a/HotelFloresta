using Entity;
using System;
using System.Collections.Generic;
using Datos;

namespace Logica
{
    public class ClienteService
    {
        private readonly ConnectionManager _conexion;
        private readonly ClienteRepository _repositorio;
        public ClienteService(string connectionString)
        {
            _conexion = new ConnectionManager(connectionString);
            _repositorio = new ClienteRepository(_conexion);
        }

        public GuardarClienteResponse Guardar(Cliente cliente)
        {
            try
            {
                _conexion.Open();
                var clientex = _repositorio.BuscarPorIdentificacion(cliente.Identificacion);
                if (clientex != null)
                {
                    return new GuardarClienteResponse("Error el cliente ya se encuentra registrado");
                }
                _repositorio.Guardar(cliente);
                _conexion.Close();
                return new GuardarClienteResponse(cliente);
            }
            catch (Exception e)
            {
                return new GuardarClienteResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }

        public List<Cliente> ConsultarTodos()
        {
            _conexion.Open();
            List<Cliente> Clientes = _repositorio.ConsultarTodos();
            _conexion.Close();
            return Clientes;
        }

        public string Eliminar(string identificacion)
        {
            try
            {
                _conexion.Open();
                var cliente = _repositorio.BuscarPorIdentificacion(identificacion);
                if (cliente != null)
                {
                    _repositorio.Eliminar(cliente);
                    _conexion.Close();
                    return ($"El registro {cliente.Nombre} se ha eliminado satisfactoriamente.");
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

        public ModificarClienteResponse ModificarCliente(Cliente cliente)
        {            
            try
            {
                _conexion.Open();
                if (cliente != null)
                {
                    _repositorio.Modificar(cliente);
                    _conexion.Close();
                    return new ModificarClienteResponse(cliente);
                }
                else
                {
                    return new ModificarClienteResponse($"Lo sentimos, {cliente.Identificacion} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return new ModificarClienteResponse($"Error de la Aplicación: {e.Message}");
            }
            finally { _conexion.Close(); }
        }

        public Cliente BuscarxIdentificacion(string identificacion)
        {
            _conexion.Open();
            Cliente cliente = _repositorio.BuscarPorIdentificacion(identificacion);
            _conexion.Close();
            return cliente;
        }

        public class GuardarClienteResponse
        {
            public GuardarClienteResponse(Cliente cliente)
            {
                Error = false;
                Cliente = cliente;
            }
            public GuardarClienteResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Cliente Cliente { get; set; }
        }

        public class ModificarClienteResponse
        {
            public ModificarClienteResponse(Cliente cliente)
            {
                Error = false;
                Cliente = cliente;
            }
            public ModificarClienteResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Cliente Cliente { get; set; }
        }
    }
}