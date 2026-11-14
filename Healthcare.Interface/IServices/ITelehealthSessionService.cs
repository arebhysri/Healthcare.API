using Healthcare.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Interface.IServices
{
    public interface ITelehealthSessionService
    {
        Task<TelehealthSession> GetTelehealthSession(int id);
        Task<IEnumerable<TelehealthSession>> GetAllTelehealthSessions(int appintmentId);
        Task<TelehealthSession> CreateTeleSessionAsync(TelehealthSession telehealthSession);
        Task<TelehealthSession> UpdateTeleSessionAsync(TelehealthSession telehealthSession);
    }
}
