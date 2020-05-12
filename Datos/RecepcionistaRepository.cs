using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Datos{

    public class RecepcionistaRepository{
        private readonly SqlConnection _connection;
        private readonly List<Recepcionista> _recepcionistas = new List<Recepcionista>();
        public RecepcionistaRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }

        public void Guardar(Recepcionista recepcionista)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Recepcionista (Identificacion,Nombre,Edad,Sexo,Direccion,Celular,Correo,Usuario,Password) 
                                        values (@Identificacion,@Nombre,@Edad,@Sexo,@Direccion,@Celular,@Correo,@Usuario,@Password)";
                command.Parameters.AddWithValue("@Identificacion", recepcionista.Identificacion);
                command.Parameters.AddWithValue("@Nombre", recepcionista.Nombre);
                command.Parameters.AddWithValue("@Edad", recepcionista.Edad);
                command.Parameters.AddWithValue("@Sexo", recepcionista.Sexo);
                command.Parameters.AddWithValue("@Direccion", recepcionista.Direccion);
                command.Parameters.AddWithValue("@Celular", recepcionista.Celular);
                command.Parameters.AddWithValue("@Correo", recepcionista.Correo);
                command.Parameters.AddWithValue("@Usuario", recepcionista.Usuario);
                command.Parameters.AddWithValue("@Password", recepcionista.Password);
                var filas = command.ExecuteNonQuery();
            }
        }

        public void Eliminar(Recepcionista recepcionista)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from Recepcionista where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", recepcionista.Identificacion);
                command.ExecuteNonQuery();
            }
        }
        public List<Recepcionista> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Recepcionista> recepcionistas = new List<Recepcionista>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from Recepcionista ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Recepcionista recepcionista = DataReaderMapToPerson(dataReader);
                        recepcionistas.Add(recepcionista);
                    }
                }
            }
            return recepcionistas;
        }

        public Recepcionista BuscarPorIdentificacion(string identificacion)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from Recepcionista where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", identificacion);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToPerson(dataReader);
            }
        }

        private Recepcionista DataReaderMapToPerson(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Recepcionista recepcionista = new Recepcionista();
            recepcionista.Identificacion = (string)dataReader["Identificacion"];
            recepcionista.Nombre = (string)dataReader["Nombre"];
            recepcionista.Edad = (int)dataReader["Edad"];
            recepcionista.Sexo = (string)dataReader["Sexo"];
            recepcionista.Direccion = (string)dataReader["Direccion"];
            recepcionista.Celular = (string)dataReader["Celular"];
            recepcionista.Correo = (string)dataReader["Correo"];
            recepcionista.Usuario = (string)dataReader["Usuario"];
            recepcionista.Password = (string)dataReader["Password"];
            return recepcionista;
        }

        public void Modificar(Recepcionista recepcionista)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = $"UPDATE Recepcionista SET Nombre = @Nombre , Edad = @Edad , Sexo = @Sexo" +
                    $", Direccion = @Direccion , Celular = @Celular , Correo = @Correo , Usuario = @Usuario , Password = @Password WHERE Identificacion = @Identificacion";
                command.Parameters.AddWithValue("@Identificacion", recepcionista.Identificacion);
                command.Parameters.AddWithValue("@Nombre", recepcionista.Nombre);
                command.Parameters.AddWithValue("@Edad", recepcionista.Edad);
                command.Parameters.AddWithValue("@Sexo", recepcionista.Sexo);
                command.Parameters.AddWithValue("@Direccion", recepcionista.Direccion);
                command.Parameters.AddWithValue("@Celular", recepcionista.Celular);
                command.Parameters.AddWithValue("@Correo", recepcionista.Correo);
                command.Parameters.AddWithValue("@Usuario", recepcionista.Usuario);
                command.Parameters.AddWithValue("@Password", recepcionista.Password);
                var filas = command.ExecuteNonQuery();
            }
        }
    }
}