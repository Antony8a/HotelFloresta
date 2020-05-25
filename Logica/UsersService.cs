using Entity;
using System;
using System.Collections.Generic;
using Datos;

namespace Logica
{
    public class UsersService
    {
        private readonly ConnectionManager _conexion;
        private readonly UsersRepository _repositorio;
        public UsersService(string connectionString)
        {
            _conexion = new ConnectionManager(connectionString);
            _repositorio = new UsersRepository(_conexion);
        }

        public GuardarUsersResponse Guardar(Users users)
        {
            try
            {
                _conexion.Open();
                var usersx = _repositorio.BuscarPorIdentificacion(users.Usuario);
                if (usersx != null)
                {
                    return new GuardarUsersResponse("Error el usuario ya se encuentra registrado");
                }
                _repositorio.Guardar(users);
                _conexion.Close();
                return new GuardarUsersResponse(users);
            }
            catch (Exception e)
            {
                return new GuardarUsersResponse($"Error de la Aplicacion: {e.Message}");
            }
            finally { _conexion.Close(); }
        }

        public List<Users> ConsultarTodos()
        {
            _conexion.Open();
            List<Users> Userss = _repositorio.ConsultarTodos();
            _conexion.Close();
            return Userss;
        }

        public string Eliminar(string identificacion)
        {
            try
            {
                _conexion.Open();
                var users = _repositorio.BuscarPorIdentificacion(identificacion);
                if (users != null)
                {
                    _repositorio.Eliminar(users);
                    _conexion.Close();
                    return ($"El registro {users.Usuario} se ha eliminado satisfactoriamente.");
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

        public ModificarUsersResponse Modificar(Users users)
        {            
            try
            {
                _conexion.Open();
                if (users != null)
                {
                    _repositorio.Modificar(users);
                    _conexion.Close();
                    return new ModificarUsersResponse(users);
                }
                else
                {
                    return new ModificarUsersResponse($"Lo sentimos, {users.Identificacion} no se encuentra registrada.");
                }
            }
            catch (Exception e)
            {

                return new ModificarUsersResponse($"Error de la Aplicación: {e.Message}");
            }
            finally { _conexion.Close(); }
        }

        public Users BuscarxIdentificacion(string identificacion)
        {
            _conexion.Open();
            Users users = _repositorio.BuscarPorIdentificacion(identificacion);
            _conexion.Close();
            return users;
        }

        public class GuardarUsersResponse
        {
            public GuardarUsersResponse(Users users)
            {
                Error = false;
                Users = users;
            }
            public GuardarUsersResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Users Users { get; set; }
        }

        public class ModificarUsersResponse
        {
            public ModificarUsersResponse(Users users)
            {
                Error = false;
                Users = users;
            }
            public ModificarUsersResponse(string mensaje)
            {
                Error = true;
                Mensaje = mensaje;
            }
            public bool Error { get; set; }
            public string Mensaje { get; set; }
            public Users Users { get; set; }
        }
    }
}