using Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Datos{

    public class HabitacionRepository{
        private readonly SqlConnection _connection;
        private readonly List<Habitacion> _habitaciones = new List<Habitacion>();
        public HabitacionRepository(ConnectionManager connection)
        {
            _connection = connection._conexion;
        }

        public void Guardar(Habitacion habitacion)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = @"Insert Into Habitacion (IdHabitacion,Tipo,Precio,Descripcion,Aire,Ventilador,Disponibilidad) 
                                        values (@IdHabitacion,@Tipo,@Precio,@Descripcion,@Aire,@Ventilador,@Disponibilidad)";
                command.Parameters.AddWithValue("@IdHabitacion", habitacion.IdHabitacion);
                command.Parameters.AddWithValue("@Tipo", habitacion.Tipo);
                command.Parameters.AddWithValue("@Precio", habitacion.Precio);
                command.Parameters.AddWithValue("@Descripcion", habitacion.Descripcion);
                command.Parameters.AddWithValue("@Aire", habitacion.Aire);
                command.Parameters.AddWithValue("@Ventilador", habitacion.Ventilador);
                command.Parameters.AddWithValue("@Disponibilidad", habitacion.Disponibilidad);
                var filas = command.ExecuteNonQuery();
            }
        }

        public void Eliminar(Habitacion habitacion)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Delete from Habitacion where IdHabitacion=@IdHabitacion";
                command.Parameters.AddWithValue("@IdHabitacion", habitacion.IdHabitacion);
                command.ExecuteNonQuery();
            }
        }

        public List<Habitacion> ConsultarTodos()
        {
            SqlDataReader dataReader;
            List<Habitacion> habitaciones = new List<Habitacion>();
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "Select * from Habitacion ";
                dataReader = command.ExecuteReader();
                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        Habitacion habitacion = DataReaderMapTo(dataReader);
                        habitaciones.Add(habitacion);
                    }
                }
            }
            return habitaciones;
        }

        public Habitacion BuscarPorIdentificacion(string identificacion)
        {
            SqlDataReader dataReader;
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = "select * from Habitacion where IdHabitacion=@IdHabitacion";
                command.Parameters.AddWithValue("@IdHabitacion", identificacion);
                dataReader = command.ExecuteReader();
                dataReader.Read();
                return DataReaderMapTo(dataReader);
            }
        }

        private Habitacion DataReaderMapTo(SqlDataReader dataReader)
        {
            if(!dataReader.HasRows) return null;
            Habitacion habitacion = new Habitacion();
            habitacion.IdHabitacion = (string)dataReader["IdHabitacion"];
            habitacion.Tipo = (string)dataReader["Tipo"];
            habitacion.Precio = (decimal)dataReader["Precio"];
            habitacion.Descripcion = (string)dataReader["Descripcion"];
            habitacion.Aire = (string)dataReader["Aire"];
            habitacion.Ventilador = (string)dataReader["Ventilador"];
            habitacion.Disponibilidad = (string)dataReader["Disponibilidad"];
            return habitacion;
        }

        public void Modificar(Habitacion habitacion)
        {
            using (var command = _connection.CreateCommand())
            {
                command.CommandText = $"UPDATE Habitacion SET Tipo = @Tipo, Precio = @Precio, Descripcion = @Descripcion" +
                    $", Aire = @Aire , Ventilador = @Ventilador , Disponibilidad = @Disponibilidad WHERE IdHabitacion = @IdHabitacion";
                command.Parameters.AddWithValue("@IdHabitacion", habitacion.IdHabitacion);
                command.Parameters.AddWithValue("@Tipo", habitacion.Tipo);
                command.Parameters.AddWithValue("@Precio", habitacion.Precio);
                command.Parameters.AddWithValue("@Descripcion", habitacion.Descripcion);
                command.Parameters.AddWithValue("@Aire", habitacion.Aire);
                command.Parameters.AddWithValue("@Ventilador", habitacion.Ventilador);
                command.Parameters.AddWithValue("@Disponibilidad", habitacion.Disponibilidad);
                var filas = command.ExecuteNonQuery();
            }
        }
    }
}