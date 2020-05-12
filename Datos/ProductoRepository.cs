using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Datos{

    public class ProductoRepository{
        private readonly SqlConnection _connection;
        private readonly List<Producto> _productos = new List<Producto>();
        public ProductoRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }

        public void Guardar(Producto producto)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Producto (IdProducto,Nombre,Precio,Tipo) 
                                        values (@IdProducto,@Nombre,@Precio,@Tipo)";
                command.Parameters.AddWithValue("@IdProducto", producto.IdProducto);
                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@Tipo", producto.Tipo);
                command.Parameters.AddWithValue("@Precio", producto.Precio);
                var filas = command.ExecuteNonQuery();
            }
        }

        public void Eliminar(Producto producto)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from Producto where IdProducto=@IdProducto";
                command.Parameters.AddWithValue("@IdProducto", producto.IdProducto);
                command.ExecuteNonQuery();
            }
        }

        public List<Producto> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Producto> productos = new List<Producto>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from producto ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Producto producto = DataReaderMapTo(dataReader);
                        productos.Add(producto);
                    }
                }
            }
            return productos;
        }

        public Producto BuscarPorIdentificacion(string identificacion)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from Producto where IdProducto = @IdProducto";
                command.Parameters.AddWithValue("@IdProducto", identificacion);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapTo(dataReader);
            }
        }

        private Producto DataReaderMapTo(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Producto producto = new Producto();
            producto.IdProducto = (string)dataReader["IdProducto"];
            producto.Nombre = (string)dataReader["Nombre"];
            producto.Tipo = (string)dataReader["Tipo"];
            producto.Precio = (decimal)dataReader["Precio"];
            return producto;
        }

        public void Modificar(Producto producto)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = $"UPDATE Producto SET Tipo = @Tipo, Precio = @Precio, Nombre = @Nombre WHERE IdProducto = @IdProducto";
                command.Parameters.AddWithValue("@IdProducto", producto.IdProducto);
                command.Parameters.AddWithValue("@Nombre", producto.Nombre);
                command.Parameters.AddWithValue("@Tipo", producto.Tipo);
                command.Parameters.AddWithValue("@Precio", producto.Precio);
                var filas = command.ExecuteNonQuery();
            }
        }
    }
}