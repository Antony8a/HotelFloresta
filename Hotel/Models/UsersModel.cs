using System.Net.Http.Headers;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace Hotel.Models
{
    public class UsersInputModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        //[RegularExpression(@"^(?=.*\d)(?=.*[\u0021-\u002b\u003c-\u0040])(?=.*[A-Z])(?=.*[a-z])\S{8,16}$", ErrorMessage ="La contraseña debe tener al entre 8 y 16 caracteres, al menos un dígito, al menos una minúscula, al menos una mayúscula y al menos un caracter no alfanumérico.")]        
        public string Password { get; set; }

        [Required]
        public string TipoUsuario { get; set; }

    }

    public class TipoUsuarioValidacion : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((value.ToString().ToUpper() == "cliente") || (value.ToString().ToUpper() == "recepcionista") || (value.ToString().ToUpper() == "admin"))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult(ErrorMessage);
            }
        }
    }

    public class UsersViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        [JsonIgnore] //no se para que
        public string Password { get; set; }
        public string Tipo { get; set; }
        public string Token { get; set; }
    }
}