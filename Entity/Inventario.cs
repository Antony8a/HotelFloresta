using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Inventario
    {
        [Key]
        public string IdInventario { get; set; }
        public string IdProducto { get; set; }
        public DateTime Fecha      { get; set; }
    }
}