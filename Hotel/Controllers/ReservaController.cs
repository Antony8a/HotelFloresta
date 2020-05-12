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
    public class ReservaController : ControllerBase
    {
        private readonly ReservaService _reservaService;
        public IConfiguration Configuration { get; }
        public ReservaController(IConfiguration configuration)
        {
            Configuration = configuration;
            string connectionString = Configuration["ConnectionStrings:DefaultConnection"];
            _reservaService = new ReservaService(connectionString);
        }
        // GET: api/Reserva
        [HttpGet]
        public IEnumerable<ReservaViewModel> Gets()
        {
            var recepcionistas = _reservaService.ConsultarTodos().Select(p=> new ReservaViewModel(p));
            return recepcionistas;
        }

        // GET: api/Recepcionista/5
        [HttpGet("{identificacion}")]
        public ActionResult<ReservaViewModel> Get(int identificacion)
        {
            var reserva = _reservaService.BuscarxIdentificacion(identificacion);
            if (reserva == null) return NotFound();
            var reservaViewModel = new ReservaViewModel(reserva);
            return reservaViewModel;
        }

        // POST: api/Reserva
        [HttpPost]
        public ActionResult<ReservaViewModel> Post(ReservaInputModel reservaInput)
        {
            Reserva reserva = MapearReserva(reservaInput);
            var response = _reservaService.Guardar(reserva);
            if (response.Error) 
            {
                ModelState.AddModelError("Guardar reserva", response.Mensaje);
                var problemDetails = new ValidationProblemDetails(ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                return BadRequest(response.Mensaje);
            }
            return Ok(response.Reserva);
        }
        
        // DELETE: api/Reserva/5
        [HttpDelete("{identificacion}")]
        public ActionResult<int> Delete(int identificacion)
        {
            int mensaje = _reservaService.Eliminar(identificacion);
            return Ok(mensaje);
        }

        private Reserva MapearReserva(ReservaInputModel reservaInput)
        {
            var reserva = new Reserva
            {
                IdReserva = reservaInput.IdReserva,
                FechaInicio = reservaInput.FechaInicio,
                FechaFin = reservaInput.FechaFin,
                CantidadPersonas = reservaInput.CantidadPersonas,
                IdCliente = reservaInput.IdCliente,
                IdHabitacion = reservaInput.IdHabitacion,
            };
            return reserva;
        }
        
        // PUT: api/Reserva/5
        [HttpPut("{identificacion}")]
        public ActionResult<ReservaViewModel> Put(string identificacion, ReservaInputModel reservaInput)
        {
            Reserva reserva = MapearReserva(reservaInput);
            var id=_reservaService.BuscarxIdentificacion(reserva.IdReserva);
            if(id==null){
                return BadRequest("No encontrado");
            }else
            {
                var response = _reservaService.Modificar(reserva);
                if (response.Error) 
                {
                    ModelState.AddModelError("Modificar Reserva", response.Mensaje);
                    var problemDetails = new ValidationProblemDetails(ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest,
                    };
                    return BadRequest(response.Mensaje);
                }
                return Ok(response.Reserva);                
            }
        }
    }
}