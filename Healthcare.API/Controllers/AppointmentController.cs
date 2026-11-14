using Healthcare.Interface.IServices;
using Healthcare.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(Appointment appointment)
        {
            var result = await _appointmentService.CreateAppointmentAsync(appointment);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _appointmentService.GetAppointmentById(id);
            if (result == null) return NotFound();
            return Ok(result);
        }
        
        [HttpPut]
        public async Task<IActionResult> Update(Appointment appointment)
            => Ok(await _appointmentService.UpdateAppointmentAsync(appointment));
    }
}
