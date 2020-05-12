using Entity;
using System;
using System.Collections.Generic;
using Datos;

namespace Logica
{
    public class ProductoService
    {
        private readonly ConnectionManager _conexion;
        private readonly ProductoRepository _repositorio;
        public ProductoService(string connectionString)
        {
            _conexion = new ConnectionManager(connectionString);
            _repositorio = new ProductoRepository(_conexion);
        }

        public GuardarProductoResponse Guardar(Producto producto)
        {
            try
            {
                _conexion.Open();
                var productox = _repositorio.BuscarPorIdentificacion(producto.IdProducto);
                if (productox != null)
                {
                    return new GuardarProductoResponse("Error este producto ya se encuentra registrado");
                }
                _repositorio.Guardar(producto);
                _conexion.Close();
                return new GuardarProductoResponse(producto);
            }
            catch (Exception e)
            {
                return new GuardarProductoResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }

        public List<Producto> ConsultarTodos()
        {
            _conexion.Open();
            List<Producto> productos = _repositorio.ConsultarTodos();
            _conexion.Close();
            return productos;
        }

        public string Eliminar(string identificacion)
        {
            try
            {
                _conexion.Open();
                var producto = _repositorio.BuscarPorIdentificacion(identificacion);
                if (producto != null)
                {
                    _repositorio.Eliminar(producto);
                    _conexion.Close();
                    return ($"El registro {producto.IdProducto} se ha eliminado satisfactoriamente.");
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

        public ModificarProductoResponse Modificar(Producto producto)
        {            
            try
            {
                _conexion.Open();
                if (producto != null)
                {
                    _repositorio.Modificar(producto);
                    _conexion.Close();
                    return new ModificarProductoResponse(producto);
                }
                else
                {
                    return new ModificarProductoResponse($"Lo sentimos, {producto.IdProducto} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return new ModificarProductoResponse($"Error de la Aplicación: {e.Message}");
            }
            finally { _conexion.Close(); }
        }

        public Producto BuscarxIdentificacion(string identificacion)
        {
            _conexion.Open();
            Producto producto = _repositorio.BuscarPorIdentificacion(identificacion);
            _conexion.Close();
            return producto;
        }

        public class GuardarProductoResponse
        {
            public GuardarProductoResponse(Producto producto)
            {
                Error = false;
                Producto = producto;
            }
            public GuardarProductoResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Producto Producto { get; set; }
        }

        public class ModificarProductoResponse
        {
            public ModificarProductoResponse(Producto producto)
            {
                Error = false;
                Producto = producto;
            }
            public ModificarProductoResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Producto Producto { get; set; }
        }
    }
}