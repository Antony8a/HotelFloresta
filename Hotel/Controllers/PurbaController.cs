using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Logica;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Hotel.Models;
using Datos;

namespace Hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurbaController : ControllerBase
    {
        
        private readonly ClienteService _clienteService;
        private readonly UsersService _usersService;

        public ActionResult Mensaje { get; set; }

        public PurbaController(HotelContext context)
        {
            _clienteService = new ClienteService(context);
            _usersService = new UsersService(context);
        }

        // POST: api/Cliente
        [HttpPost]
        public ActionResult<ClienteViewModel> Post(ClienteInputModel clienteInput)
        {
            Cliente cliente = MapearCliente(clienteInput);
            Users users = MapearUsers(clienteInput);
            var response = _usersService.Guardar(users);
            if (response.Error) 
            {
                ModelState.AddModelError("Guardar usuario", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            } else {
                Mensaje = Ok(response.Users);
                var response1 = _clienteService.Guardar(cliente);
                if (response1.Error) 
                {
                    _usersService.Eliminar(users.Usuario);
                    ModelState.AddModelError("Guardar Cliente", response1.Mensaje);
                    var problemDetails = new ValidationProblemDetails(ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest,
                    };
                        return BadRequest(problemDetails);
                    }else
                    {
                        Mensaje = Ok(response1.Cliente);
                    }             
                }
            return Mensaje;
        }

        private Cliente MapearCliente(ClienteInputModel clienteInput)
        {
            var cliente = new Cliente
            {
                Identificacion = clienteInput.Identificacion,
                Nombre = clienteInput.Nombre,
                Edad = clienteInput.Edad,
                Sexo = clienteInput.Sexo,
                Direccion = clienteInput.Direccion,
                Celular = clienteInput.Celular,
                Correo = clienteInput.Correo,
                Usuario = clienteInput.Usuario,
                Password = clienteInput.Password,
            };
            return cliente;
        }

        private Users MapearUsers(ClienteInputModel clienteInput)
        {
            var users = new Users
            {
                Identificacion = clienteInput.Identificacion,
                TipoUsuario = "cliente",
                Usuario = clienteInput.Usuario,
                Password = clienteInput.Password,
            };
            return users;
        }
    }
}