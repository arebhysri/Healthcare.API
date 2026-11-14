using Healthcare.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Interface.IRepository
{
    public interface ITelehealthSessionRepository
    {
        Task<TelehealthSession> GetSessionByIdAsync(int id);
        Task<IEnumerable<TelehealthSession>> GetAllSessionsByAppointmentIdAsync(int appointmentId);
        Task<TelehealthSession> CreateSessionAsync(TelehealthSession session);
        Task<TelehealthSession> UpdateSessionAsync(TelehealthSession session);
    }
}
