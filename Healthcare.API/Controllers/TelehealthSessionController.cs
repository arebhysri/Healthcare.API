using Healthcare.Interface.IServices;
using Healthcare.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelehealthSessionController : ControllerBase
    {
        private readonly ITelehealthSessionService _telehealthSessionService;
        public TelehealthSessionController(ITelehealthSessionService telehealthSessionService)
        {
            _telehealthSessionService = telehealthSessionService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _telehealthSessionService.GetTelehealthSession(id);
            return Ok(result);
        }

        [HttpGet("appointment/{appointmentId}")]
        public async Task<IActionResult> GetAll(int appointmentId)
        {
            var result = await _telehealthSessionService.GetAllTelehealthSessions(appointmentId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TelehealthSession telehealthSession)
        {
            var result = await _telehealthSessionService.CreateTeleSessionAsync(telehealthSession);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TelehealthSession telehealthSession)
        {
            var result = await _telehealthSessionService.UpdateTeleSessionAsync(telehealthSession);
            return Ok(result);
        }

    }
}
