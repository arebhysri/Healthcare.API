using Healthcare.Interface.IRepository;
using Healthcare.Interface.IServices;
using Healthcare.model;
using Healthcare.model.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Services
{
    public class TelehealthSessionService : ITelehealthSessionService
    {
        private readonly ITelehealthSessionRepository _telehealthSessionRepository;

        public TelehealthSessionService(ITelehealthSessionRepository telehealthSessionRepository)
        {
            _telehealthSessionRepository = telehealthSessionRepository;
        }

        public async Task<TelehealthSession> CreateTeleSessionAsync(TelehealthSession telehealthSession)
        {
            if (telehealthSession == null)
            {
                throw new ArgumentNullException(nameof(telehealthSession));
            }
            telehealthSession.Id = 0;
            await _telehealthSessionRepository.CreateSessionAsync(telehealthSession);
            return telehealthSession;
        }

        public Task<IEnumerable<TelehealthSession>> GetAllTelehealthSessions(int appintmentId)
            => _telehealthSessionRepository.GetAllSessionsByAppointmentIdAsync(appintmentId);

        public Task<TelehealthSession> GetTelehealthSession(int id)
            => _telehealthSessionRepository.GetSessionByIdAsync(id);

        public async Task<TelehealthSession> UpdateTeleSessionAsync(TelehealthSession telehealthSession)
        {
            if (telehealthSession == null)
            {
                throw new ArgumentNullException(nameof(telehealthSession));
            }
            await _telehealthSessionRepository.UpdateSessionAsync(telehealthSession);
            return telehealthSession;
        }
    }
}
