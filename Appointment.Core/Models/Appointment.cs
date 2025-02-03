using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Core.Models
{
    public class Appointment: Base
    {
        public Guid PatientId { get; set; }     // Reference to Patient (from Auth Service)
        public Guid DoctorId { get; set; }      // Reference to Doctor (from Auth Service)
        public DateTime StartTime { get; set; } // Appointment start time
        public DateTime EndTime { get; set; }   // Appointment end time
        public string Status { get; set; }      // "Scheduled", "Completed", "Cancelled"
    }
}
