using Healthcare.Interface.IServices;
using Healthcare.model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Healthcare.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var patient = await _patientService.GetPatientById(id);
            if (patient == null) return NotFound(); 
            return Ok(patient);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var patients = await _patientService.GetAllPatients();
            return Ok(patients);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Patient patient)
        {
            if (patient == null) throw new ArgumentNullException(nameof(patient));
            var created = await _patientService.CreatePatientAsync(patient);
            return Ok(created);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Patient patient)
        {
            if (patient == null) throw new ArgumentNullException(nameof(patient));
            var updated = await _patientService.UpdatePatientAsync(patient);
            return Ok(updated);
        }
    }
}
