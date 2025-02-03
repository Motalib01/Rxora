namespace Appointment.Core.Models
{
    public class DoctorAvailability: Base
    {
        public Guid DoctorId { get; set; }      // Reference to Doctor
        public DateTime StartTime { get; set; } // Availability start time
        public DateTime EndTime { get; set; }   // Availability end time
    }
}
