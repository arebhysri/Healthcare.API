using Healthcare.Data;
using Healthcare.Interface.IRepository;
using Healthcare.model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Repository
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly HealthCareDbContext _context;

        public AppointmentRepository(HealthCareDbContext context)
        {
            _context=context;
        }

        public async Task AddAppointmentAsync(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Appointment>> GetAllByPatient(int patientId)
            => await _context.Appointments.Where(a => a.PatientId == patientId).ToListAsync();

        public Task<Appointment> GetAppointmentById(int id)
            => _context.Appointments.FirstOrDefaultAsync(a => a.Id == id);

        public async Task UpdateAppointmentAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }
    }
}
