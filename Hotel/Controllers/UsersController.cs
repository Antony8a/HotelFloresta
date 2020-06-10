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
using Microsoft.Extensions.Options;
using Hotel.ClientApp.Config;
using Hotel.Service;
using Microsoft.AspNetCore.Authorization;

namespace Hotel.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        UsersService _usersService;
        HotelContext _context;  
        JwtService _jwtService;
        public UsersController(HotelContext context, IOptions<AppSetting> appSettings)
        {
            _context = context;
            var admin = _context.Userss.Find("admin");
            if (admin == null)
            {
                _context.Userss.Add(new Users()
                {
                    Identificacion = "000",
                    Password = "admin",
                    Usuario = "admin",
                    TipoUsuario = "Adminitrador",
                }
                );

                var registrosGuardados = _context.SaveChanges();

            }
            _usersService = new UsersService(context);
            _jwtService = new JwtService(appSettings);
        }
        
        // POST: api/Users
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UsersInputModel model)
        {
            var user = _usersService.Validate(model.Usuario, model.Password);
            if (user == null) return BadRequest("Username or password is incorrect");
            var response = _jwtService.GenerateToken(user);
            return Ok(response);

        }



        // GET: api/Users
        [HttpGet]
        public IEnumerable<UsersViewModel> Gets()
        {
            var userss = _usersService.ConsultarTodos().Select(p => new UsersViewModel(p));
            return userss;
        }

        // GET: api/Users/5
        [HttpGet("{Usuario}")]
        public ActionResult<UsersViewModel> Get(string Usuario)
        {
            var users = _usersService.BuscarxIdentificacion(Usuario);
            if (users == null) return NotFound();
            var usersViewModel = new UsersViewModel(users);
            return usersViewModel;
        }
        
        // POST: api/Userss
        // [HttpPost]
        // public ActionResult<UsersViewModel> Post(UsersInputModel usersInput)
        // {
        //     Users user = MapearUsers(usersInput);
        //     var response = _usersService.Guardar(user);
        //     if (response.Error) 
        //     {
        //         ModelState.AddModelError("Guardar reserva", response.Mensaje);
        //         var problemDetails = new ValidationProblemDetails(ModelState)
        //         {
        //             Status = StatusCodes.Status400BadRequest,
        //         };
        //         return BadRequest(problemDetails);
        //     }
        //     return Ok(response.Users);
        // }

        // DELETE: api/Users/5
        [HttpDelete("{Usuario}")]
        public ActionResult<string> Delete(string Usuario)
        {
            string mensaje = _usersService.Eliminar(Usuario);
            return Ok(mensaje);
        }

        private Users MapearUsers(UsersInputModel usersInput)
        {
            var users = new Users
            {
                Usuario = usersInput.Usuario,
                Password = usersInput.Password,
                TipoUsuario = usersInput.TipoUsuario,
                Identificacion = usersInput.Identificacion,
            };
            return users;
        }

        // PUT: api/Users/5
        [HttpPut("{Usuario}")]
        public ActionResult<UsersViewModel> Put(string Usuario, UsersInputModel usersInput)
        {
            Users users = MapearUsers(usersInput);
            var id = _usersService.BuscarxIdentificacion(users.Usuario);
            if (id == null)
            {
                return BadRequest("No encontrado");
            }
            else
            {
                var response = _usersService.Modificar(users);
                if (response.Error)
                {
                    ModelState.AddModelError("Modificar Usuario", response.Mensaje);
                    var problemDetails = new ValidationProblemDetails(ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest,
                    };
                    return BadRequest(response.Mensaje);
                }
                return Ok(response.Users);
            }
        }
    }
}