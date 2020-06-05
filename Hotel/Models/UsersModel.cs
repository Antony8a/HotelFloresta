using System.Net.Http.Headers;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Models
{
    public class UsersInputModel
    {
        [Required(ErrorMessage = "El Usuario es requerido")]
        public string Usuario { get; set; }

        [Required(ErrorMessage = "La contraseña es requerida")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "La contraseña debe tener como maximo 20 y minimo 4 caracteres")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El Tipo de usuario es requerido")]
        [TipoUsuarioValidacion( ErrorMessage="El Tipo de usuario debe ser cliente, recepcionista o admin")]
        public string TipoUsuario { get; set; }

        [Required(ErrorMessage = "La identificacion es requerida")]
        public string Identificacion { get; set; }
        
        [Required(ErrorMessage = "La identificacion es requerida")]
        public string Token { get; set; }
    }

    public class TipoUsuarioValidacion : ValidationAttribute{
        protected override ValidationResult IsValid(object value, ValidationContext validationContext) 
        {
            if ((value.ToString().ToUpper() == "CLIENTE") || (value.ToString().ToUpper() == "RECEPCIONISTA") || (value.ToString().ToUpper() == "ADMIN"))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage);
            }
        }
    }

    public class UsersViewModel : UsersInputModel
    {
        public UsersViewModel()
        {

        }
        public UsersViewModel(Users users)
        {
            Usuario = users.Usuario;
            Password = users.Password;
            TipoUsuario = users.TipoUsuario;
            Identificacion = users.Identificacion;
        }
    }
}