using Appointment.Core.Repositores;
using Appointment.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorAvailabilityController : ControllerBase
    {
        private readonly IRepository<DoctorAvailability> _doctorAvailability;

        public DoctorAvailabilityController(IRepository<DoctorAvailability> doctorAvailability)
        {
            _doctorAvailability = doctorAvailability;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctorAvailabilityAsync()
        {
            var doctorAvailability = await _doctorAvailability.GetAllAsync();
            return Ok(doctorAvailability);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDoctorAvailabilityByIdAsync(Guid id)
        {
            var doctorAvailability = await _doctorAvailability.GetByIdAsync(id);
            if (doctorAvailability != null)
                return Ok(doctorAvailability);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateDoctorAvailabilityAsync([FromBody] Core.Models.DoctorAvailability DoctorAvailability)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _doctorAvailability.CreateAsync(DoctorAvailability);

            return Ok(DoctorAvailability);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctorAvailabilityAsync(Guid id, [FromBody] Core.Models.DoctorAvailability DoctorAvailability)
        {
            if (id != DoctorAvailability.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _doctorAvailability.UpdateAsync(DoctorAvailability);
            return Ok(DoctorAvailability);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctorAvailabilityAsync(Guid id)
        {
            var DoctorAvailability = await _doctorAvailability.DeleteAsync(id);
            if (DoctorAvailability != null)
                return Ok(DoctorAvailability);

            return NotFound();
        }
    }
}
