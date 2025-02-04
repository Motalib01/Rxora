using Appointment.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appointment.Core.Data
{
    public class AppointmentDBContext: DbContext
    {
        public AppointmentDBContext(DbContextOptions<AppointmentDBContext> options) : base(options)
        {
        }
        
        public DbSet<DoctorAvailability> DoctorAvailabilities { get; set; }
        public DbSet<Models.Appointment> Appointments { get; set; }
    }
}
