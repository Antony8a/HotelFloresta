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
    public class RecepcionistaController : ControllerBase
    {
        private readonly RecepcionistaService _recepcionistaService;
        public IConfiguration Configuration { get; }
        public RecepcionistaController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _recepcionistaService = new RecepcionistaService(connectionString);
        }
        // GET: api/Recepcionista
        [HttpGet]
        public IEnumerable<RecepcionistaViewModel> Gets()
        {
            var recepcionistas = _recepcionistaService.ConsultarTodos().Select(p=> new RecepcionistaViewModel(p));
            return recepcionistas;
        }

        // GET: api/Recepcionista/5
        [HttpGet("{identificacion}")]
        public ActionResult<RecepcionistaViewModel> Get(string identificacion)
        {
            var recepcionista = _recepcionistaService.BuscarxIdentificacion(identificacion);
            if (recepcionista == null) return NotFound();
            var recepcionistaViewModel = new RecepcionistaViewModel(recepcionista);
            return recepcionistaViewModel;
        }

        // POST: api/Recepcionista
        [HttpPost]
        public ActionResult<RecepcionistaViewModel> Post(RecepcionistaInputModel recepcionistaInput)
        {
            Recepcionista recepcionista = MapearRecepcionista(recepcionistaInput);
            var response = _recepcionistaService.Guardar(recepcionista);
            if (response.Error) 
            {
                ModelState.AddModelError("Guardar Recepcionista", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(problemDetails);
            }
            return Ok(response.Recepcionista);
        }
        
        // DELETE: api/Recepcionista/5
        [HttpDelete("{identificacion}")]
        public ActionResult<string> Delete(string identificacion)
        {
            string mensaje = _recepcionistaService.Eliminar(identificacion);
            return Ok(mensaje);
        }

        private Recepcionista MapearRecepcionista(RecepcionistaInputModel recepcionistaInput)
        {
            var recepcionista = new Recepcionista
            {
                Identificacion = recepcionistaInput.Identificacion,
                Nombre = recepcionistaInput.Nombre,
                Edad = recepcionistaInput.Edad,
                Sexo = recepcionistaInput.Sexo,
                Direccion = recepcionistaInput.Direccion,
                Celular = recepcionistaInput.Celular,
                Correo = recepcionistaInput.Correo,
                Usuario = recepcionistaInput.Usuario,
                Password = recepcionistaInput.Password,
            };
            return recepcionista;
        }
        
        // PUT: api/Recepcionista/5
        [HttpPut("{identificacion}")]
        public ActionResult<RecepcionistaViewModel> Put(string identificacion, RecepcionistaInputModel recepcionistaInput)
        {
            Recepcionista recepcionista = MapearRecepcionista(recepcionistaInput);
            var id=_recepcionistaService.BuscarxIdentificacion(recepcionista.Identificacion);
            if(id==null){
                return BadRequest("No encontrado");
            }else
            {
                var response = _recepcionistaService.ModificarRecepcionista(recepcionista);
                if (response.Error) 
                {
                    ModelState.AddModelError("Modificar Recepcionista", response.Mensaje);
                    var problemDetails = new ValidationProblemDetails(ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest,
                    };
                    return BadRequest(problemDetails);
                }
                return Ok(response.Recepcionista);                
            }
        }
    }
}