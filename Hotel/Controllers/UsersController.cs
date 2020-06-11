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
                _context.Userss.Add(new Entity.Users() 
                { 
                    UserName = "admin", 
                    Password = "admin", 
                    Email = "admin@gmail.com", 
                    Estado = "AC", 
                    FirstName = "Adminitrador", 
                    LastName = "    ", 
                    MobilePhone = "318000",
                    TipoUsuario="Administrador" });

                var registrosGuardados = _context.SaveChanges();

            }
            _usersService = new UsersService(context);
            _jwtService = new JwtService(appSettings);
        }
        
        

        [AllowAnonymous]
        [HttpPost()]
        public IActionResult Login(UsersInputModel model)
        {
            var user = _usersService.Validate(model.UserName, model.Password);

            if (user == null)
            {
                ModelState.AddModelError("Acceso Denegado", "Username or password is incorrect");
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            var response = _jwtService.GenerateToken(user);

            return Ok(response);
        }


    }
}