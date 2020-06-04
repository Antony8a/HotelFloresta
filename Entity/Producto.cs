using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Producto
    {
        public string IdProducto { get; set; }
        public string Nombre     { get; set; }
        public string Tipo       { get; set; }
        public decimal Precio    { get; set; }
    }
}