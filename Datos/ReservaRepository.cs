using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Datos{

    public class ReservaRepository{
        private readonly SqlConnection _connection;
        private readonly List<Reserva> _reservas = new List<Reserva>();
        public ReservaRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }

        public void Guardar(Reserva reserva)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Reserva (FechaInicio,FechaFin,CantidadPersonas,IdCliente,IdHabitacion) 
                                        values (@FechaInicio,@FechaFin,@CantidadPersonas,@IdCliente,@IdHabitacion)";
                command.Parameters.AddWithValue("@FechaInicio", reserva.FechaInicio);
                command.Parameters.AddWithValue("@FechaFin", reserva.FechaFin);
                command.Parameters.AddWithValue("@CantidadPersonas", reserva.CantidadPersonas);
                command.Parameters.AddWithValue("@IdCliente", reserva.IdCliente);
                command.Parameters.AddWithValue("@IdHabitacion", reserva.IdHabitacion);
                var filas = command.ExecuteNonQuery();
            }
        }

        public void Eliminar(Reserva reserva)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from Reserva where IdReserva=@IdReserva";
                command.Parameters.AddWithValue("@IdReserva", reserva.IdReserva);
                command.ExecuteNonQuery();
            }
        }

        public List<Reserva> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Reserva> reservas = new List<Reserva>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from Reserva ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Reserva reserva = DataReaderMapTo(dataReader);
                        reservas.Add(reserva);
                    }
                }
            }
            return reservas;
        }

        public Reserva BuscarPorIdentificacion(int identificacion)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from Reserva where IdReserva=@IdReserva";
                command.Parameters.AddWithValue("@IdReserva", identificacion);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapTo(dataReader);
            }
        }

        private Reserva DataReaderMapTo(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Reserva reserva = new Reserva();
            reserva.IdReserva = (int)dataReader["IdReserva"];
            reserva.FechaInicio = (DateTime)dataReader["FechaInicio"];
            reserva.FechaFin = (DateTime)dataReader["FechaFin"];
            reserva.CantidadPersonas = (decimal)dataReader["CantidadPersonas"];
            reserva.IdCliente = (string)dataReader["IdCliente"];
            reserva.IdHabitacion = (string)dataReader["IdHabitacion"];
            return reserva;
        }

        public void Modificar(Reserva reserva)
        {
            using (var command = _connection.CreateCommand())
            {  
                command.CommandText = $"UPDATE Reserva SET FechaInicio = @FechaInicio, FechaFin = @FechaFin"+
                $", CantidadPersonas = @CantidadPersonas, IdCliente = @IdCliente, IdHabitacion = @IdHabitacion WHERE IdReserva = @IdReserva";
                command.Parameters.AddWithValue("@IdReserva", reserva.IdReserva);
                command.Parameters.AddWithValue("@FechaInicio", reserva.FechaInicio);
                command.Parameters.AddWithValue("@FechaFin", reserva.FechaFin);
                command.Parameters.AddWithValue("@CantidadPersonas", reserva.CantidadPersonas);
                command.Parameters.AddWithValue("@IdCliente", reserva.IdCliente);
                command.Parameters.AddWithValue("@IdHabitacion", reserva.IdHabitacion);
                var filas = command.ExecuteNonQuery();
            }
        }
    }
}