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
    public class TelehealthSessionRepository : ITelehealthSessionRepository
    {
        private readonly HealthCareDbContext _healthCareDbContext;
        public TelehealthSessionRepository(HealthCareDbContext healthCareDbContext)
        {
            _healthCareDbContext = healthCareDbContext;
        }

        public Task<TelehealthSession> GetSessionByIdAsync(int id)
            => _healthCareDbContext.TelehealthSessions.FirstOrDefaultAsync(s => s.Id == id);

        public Task<IEnumerable<TelehealthSession>> GetAllSessionsByAppointmentIdAsync(int appointmentId)
            => Task.FromResult<IEnumerable<TelehealthSession>>(
                _healthCareDbContext.TelehealthSessions.Where(s => s.AppointmentId == appointmentId).ToList());
        public async Task<TelehealthSession> CreateSessionAsync(TelehealthSession session)
        {
            _healthCareDbContext.TelehealthSessions.Add(session);
            await _healthCareDbContext.SaveChangesAsync();
            return session;
        }
        public async Task<TelehealthSession> UpdateSessionAsync(TelehealthSession session)
        {
            _healthCareDbContext.TelehealthSessions.Update(session);
            await _healthCareDbContext.SaveChangesAsync();
            return session;
        }
    }
}
