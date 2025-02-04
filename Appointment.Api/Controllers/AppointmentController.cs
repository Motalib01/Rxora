using Appointment.Core.Models;
using Appointment.Core.Repositores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Appointment.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IRepository<Core.Models.Appointment> _appointmentRepository;

        public AppointmentController(IRepository<Core.Models.Appointment> appointmentRepository)
        {
            _appointmentRepository = appointmentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAppointmentAsync()
        {
            var appointment = await _appointmentRepository.GetAllAsync();
            return Ok(appointment);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentByIdAsync(Guid id)
        {
            var appintment = await _appointmentRepository.GetByIdAsync(id);
            if (appintment != null) 
                return Ok(appintment);

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointmentAsync([FromBody]Core.Models.Appointment appointment)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _appointmentRepository.CreateAsync(appointment);

            //return CreatedAtAction(nameof(GetAppointmentByIdAsync), new { id = appointment.Id }, appointment);
            return Ok(appointment);
        }

        [HttpPut("{id}")]
        public async Task <IActionResult> UpdateAppointmentAsync(Guid id, [FromBody] Core.Models.Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _appointmentRepository.UpdateAsync(appointment);
            return Ok(appointment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointmentAsync(Guid id)
        {
            var appointment = await _appointmentRepository.DeleteAsync(id);
            if (appointment != null)
                return Ok(appointment);


            return NotFound();
        }
    }
}
