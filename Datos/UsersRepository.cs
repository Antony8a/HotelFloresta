using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Datos
{
    public class UsersRepository{
        private readonly SqlConnection _connection;
        private readonly List<Users> _userss = new List<Users>();
        public UsersRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }

        public void Guardar(Users users)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Users (Usuario,Password,TipoUsuario,Identificacion) 
                                        values (@Usuario,@Password,@TipoUsuario,@Identificacion)";
                command.Parameters.AddWithValue("@Usuario", users.Usuario);
                command.Parameters.AddWithValue("@Password", users.Password);
                command.Parameters.AddWithValue("@TipoUsuario", users.TipoUsuario);
                command.Parameters.AddWithValue("@Identificacion", users.Identificacion);
                var filas = command.ExecuteNonQuery();
            }
        }

        public void Eliminar(Users users)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from Users where Usuario=@Usuario";
                command.Parameters.AddWithValue("@Usuario", users.Usuario);
                command.ExecuteNonQuery();
            }
        }

        public List<Users> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Users> userss = new List<Users>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from Users ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Users users = DataReaderMapTo(dataReader);
                        userss.Add(users);
                    }
                }
            }
            return userss;
        }

        public Users BuscarPorIdentificacion(string identificacion)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from Users where Usuario=@Usuario";
                command.Parameters.AddWithValue("@Usuario", identificacion);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapTo(dataReader);
            }
        }

        private Users DataReaderMapTo(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Users users = new Users();
            users.Usuario = (string)dataReader["Usuario"];
            users.Password = (string)dataReader["Password"];
            users.TipoUsuario = (string)dataReader["TipoUsuario"];
            users.Identificacion = (string)dataReader["Identificacion"];
            return users;
        }

        public void Modificar(Users users)
        {
            using (var command = _connection.CreateCommand())
            {  
                command.CommandText = $"UPDATE Users SET Password = @Password, TipoUsuario = @TipoUsuario"+
                $", Identificacion = @Identificacion WHERE Usuario = @Usuario";
                command.Parameters.AddWithValue("@Usuario", users.Usuario);
                command.Parameters.AddWithValue("@Password", users.Password);
                command.Parameters.AddWithValue("@TipoUsuario", users.TipoUsuario);
                command.Parameters.AddWithValue("@Identificacion", users.Identificacion);
                var filas = command.ExecuteNonQuery();
            }
        }
    }
}