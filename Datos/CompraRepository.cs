using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Datos{

    public class CompraRepository{
        private readonly SqlConnection _connection;
        private readonly List<Compra> _compras = new List<Compra>();
        public CompraRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }

        public void Guardar(Compra compra)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Compra (IdCompra,Fecha,TotalCompra,CantidadProductos)
                                        values (@IdCompra,@Fecha,@TotalCompra,@CantidadProductos)";
                command.Parameters.AddWithValue("@IdCompra", compra.IdCompra);
                command.Parameters.AddWithValue("@Fecha", compra.Fecha);
                command.Parameters.AddWithValue("@TotalCompra", compra.TotalCompra);
                command.Parameters.AddWithValue("@CantidadProductos", compra.CantidadProductos);
                var filas = command.ExecuteNonQuery();
            }
        }

        public void Eliminar(Compra compra)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from Compra where IdCompra=@IdCompra";
                command.Parameters.AddWithValue("@IdCompra", compra.IdCompra);
                command.ExecuteNonQuery();
            }
        }
        public List<Compra> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Compra> compras = new List<Compra>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from Compra ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Compra compra = DataReaderMapToPerson(dataReader);
                        compras.Add(compra);
                    }
                }
            }
            return compras;
        }

        public Compra BuscarPorIdentificacion(string idCompra)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from compra where IdCompra=@IdCompra";
                command.Parameters.AddWithValue("@IdCompra", idCompra);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToPerson(dataReader);
            }
        }

        private Compra DataReaderMapToPerson(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Compra compra = new Compra();
            compra.IdCompra = (string)dataReader["IdCompra"];
            compra.Fecha = (DateTime)dataReader["Fecha"];
            compra.TotalCompra = (decimal)dataReader["TotalCompra"];
            compra.CantidadProductos = (decimal)dataReader["CantidadProductos"];
            return compra;
        }

        public void Modificar(Compra compra)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = $"UPDATE Compra SET Fecha = @Fecha , TotalCompra = @TotalCompra , CantidadProductos = @CantidadProductos WHERE IdCompra = @IdCompra";
                command.Parameters.AddWithValue("@IdCompra", compra.IdCompra);
                command.Parameters.AddWithValue("@Fecha", compra.Fecha);
                command.Parameters.AddWithValue("@TotalCompra", compra.TotalCompra);
                command.Parameters.AddWithValue("@CantidadProductos", compra.CantidadProductos);
                var filas = command.ExecuteNonQuery();
            }
        }
    }
}