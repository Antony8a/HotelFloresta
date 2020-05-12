using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Datos{

    public class ClienteRepository{
        private readonly SqlConnection _connection;
        private readonly List<Cliente> _clientes = new List<Cliente>();
        public ClienteRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }

        public void Guardar(Cliente cliente)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Cliente (Identificacion,Nombre,Edad,Sexo,Direccion,Celular,Correo,Usuario,Password) 
                                        values (@Identificacion,@Nombre,@Edad,@Sexo,@Direccion,@Celular,@Correo,@Usuario,@Password)";
                command.Parameters.AddWithValue("@Identificacion", cliente.Identificacion);
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Edad", cliente.Edad);
                command.Parameters.AddWithValue("@Sexo", cliente.Sexo);
                command.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                command.Parameters.AddWithValue("@Celular", cliente.Celular);
                command.Parameters.AddWithValue("@Correo", cliente.Correo);
                command.Parameters.AddWithValue("@Usuario", cliente.Usuario);
                command.Parameters.AddWithValue("@Password", cliente.Password);
                var filas = command.ExecuteNonQuery();
            }
        }

        public void Eliminar(Cliente cliente)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from cliente where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", cliente.Identificacion);
                command.ExecuteNonQuery();
            }
        }
        public List<Cliente> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Cliente> clientes = new List<Cliente>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from cliente ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Cliente cliente = DataReaderMapToPerson(dataReader);
                        clientes.Add(cliente);
                    }
                }
            }
            return clientes;
        }

        public Cliente BuscarPorIdentificacion(string identificacion)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from cliente where Identificacion=@Identificacion";
                command.Parameters.AddWithValue("@Identificacion", identificacion);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToPerson(dataReader);
            }
        }

        private Cliente DataReaderMapToPerson(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Cliente cliente = new Cliente();
            cliente.Identificacion = (string)dataReader["Identificacion"];
            cliente.Nombre = (string)dataReader["Nombre"];
            cliente.Edad = (int)dataReader["Edad"];
            cliente.Sexo = (string)dataReader["Sexo"];
            cliente.Direccion = (string)dataReader["Direccion"];
            cliente.Celular = (string)dataReader["Celular"];
            cliente.Correo = (string)dataReader["Correo"];
            cliente.Usuario = (string)dataReader["Usuario"];
            cliente.Password = (string)dataReader["Password"];
            return cliente;
        }

        public void Modificar(Cliente cliente)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = $"UPDATE Cliente SET Nombre = @Nombre , Edad = @Edad , Sexo = @Sexo" +
                    $", Direccion = @Direccion , Celular = @Celular , Correo = @Correo , Usuario = @Usuario , Password = @Password WHERE Identificacion = @Identificacion";
                command.Parameters.AddWithValue("@Identificacion", cliente.Identificacion);
                command.Parameters.AddWithValue("@Nombre", cliente.Nombre);
                command.Parameters.AddWithValue("@Edad", cliente.Edad);
                command.Parameters.AddWithValue("@Sexo", cliente.Sexo);
                command.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                command.Parameters.AddWithValue("@Celular", cliente.Celular);
                command.Parameters.AddWithValue("@Correo", cliente.Correo);
                command.Parameters.AddWithValue("@Usuario", cliente.Usuario);
                command.Parameters.AddWithValue("@Password", cliente.Password);
                var filas = command.ExecuteNonQuery();
            }
        }
    }
}