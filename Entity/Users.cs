using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Users
    {
        [Key]
        public string Usuario           { get; set; }
        public string Password          { get; set; }
        public string TipoUsuario       { get; set; }
        public string Identificacion    { get; set; }
        public string Token             { get; set; }
        
    }
}