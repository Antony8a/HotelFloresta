using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Datos{

    public class FacturaRepository{
        private readonly SqlConnection _connection;
        private readonly List<Factura> _facturas = new List<Factura>();
        public FacturaRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }

        public void Guardar(Factura factura)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Factura (IdFactura,IdReserva,SubTotal,Total)
                                        values (@IdFactura,@IdReserva,@SubTotal,@Total)";
                command.Parameters.AddWithValue("@IdFactura", factura.IdFactura);
                command.Parameters.AddWithValue("@IdReserva", factura.IdReserva);
                command.Parameters.AddWithValue("@SubTotal", factura.SubTotal);
                command.Parameters.AddWithValue("@Total", factura.Total);
                var filas = command.ExecuteNonQuery();
            }
        }

        public void Eliminar(Factura factura)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from Factura where IdFactura=@IdFactura";
                command.Parameters.AddWithValue("@IdFactura", factura.IdFactura);
                command.ExecuteNonQuery();
            }
        }
        public List<Factura> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Factura> facturas = new List<Factura>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from Factura ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Factura factura = DataReaderMapToPerson(dataReader);
                        facturas.Add(factura);
                    }
                }
            }
            return facturas;
        }

        public Factura BuscarPorIdentificacion(string idFactura)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from Factura where IdFactura=@IdFactura";
                command.Parameters.AddWithValue("@IdFactura", idFactura);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapToPerson(dataReader);
            }
        }

        private Factura DataReaderMapToPerson(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Factura factura = new Factura();
            factura.IdFactura = (string)dataReader["IdFactura"];
            factura.IdReserva = (string)dataReader["IdReserva"];
            factura.SubTotal = (decimal)dataReader["SubTotal"];
            factura.Total = (decimal)dataReader["Total"];
            return factura;
        }

        public void Modificar(Factura factura)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = $"UPDATE Factura SET IdReserva = @IdReserva , SubTotal = @SubTotal , Total = @Total WHERE IdFactura = @IdFactura";
                command.Parameters.AddWithValue("@IdFactura", factura.IdFactura);
                command.Parameters.AddWithValue("@IdReserva", factura.IdReserva);
                command.Parameters.AddWithValue("@SubTotal", factura.SubTotal);
                command.Parameters.AddWithValue("@Total", factura.Total);
                var filas = command.ExecuteNonQuery();
            }
        }
    }
}