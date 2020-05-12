using System;

namespace Entity
{
    public class Reserva
    {
        public int IdReserva             { get; set; }
        public DateTime FechaInicio         { get; set; }
        public DateTime FechaFin            { get; set; }
        public decimal CantidadPersonas     { get; set; }
        public string IdCliente             { get; set; }
        public string IdHabitacion          { get; set; }
    }
}