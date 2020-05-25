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

namespace Hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UsersService _usersService;
        public IConfiguration Configuration { get; }
        public UsersController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _usersService = new UsersService(connectionString);
        }
        // GET: api/Users
        [HttpGet]
        public IEnumerable<UsersViewModel> Gets()
        {
            var userss = _usersService.ConsultarTodos().Select(p=> new UsersViewModel(p));
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

        // POST: api/Users
        [HttpPost]
        public ActionResult<UsersViewModel> Post(UsersInputModel usersInput)
        {
            Users users = MapearUsers(usersInput);
            var response = _usersService.Guardar(users);
            if (response.Error) 
            {
                ModelState.AddModelError("Guardar usuario", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.Users);
        }
        
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
            var id=_usersService.BuscarxIdentificacion(users.Usuario);
            if(id==null){
                return BadRequest("No encontrado");
            }else
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