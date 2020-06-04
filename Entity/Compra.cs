using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Compra
    {
        public string IdCompra { get; set; }
        public DateTime Fecha { get; set; }
        public decimal TotalCompra { get; set; }
        public decimal CantidadProductos { get; set; }
    }
}