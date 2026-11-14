using Healthcare.Interface.IRepository;
using Healthcare.Interface.IServices;
using Healthcare.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Services
{
    public class AppointmentService : IAppointmentService
    {
        private readonly IAppointmentRepository _repo;

        public AppointmentService(IAppointmentRepository repo)
        {
            _repo = repo;
        }
        public async Task<Appointment> CreateAppointmentAsync(Appointment appointment)
        {
            if (appointment.AppoinmentDate < DateTime.Now)
                throw new Exception("Appointment date cannot be in the past");
            appointment.Id = 0;
            await _repo.AddAppointmentAsync(appointment);
            return appointment;
        }

        public async Task<IEnumerable<Appointment>> GetAllByPatient(int patientId)
        {
            if (patientId < 0) throw new Exception("Patient Id cannot find");
            var appintments = await _repo.GetAllByPatient(patientId);
            return appintments;
        }

        public Task<Appointment> GetAppointmentById(int id)
            => _repo.GetAppointmentById(id);

        public async Task<Appointment> UpdateAppointmentAsync(Appointment appointment)
        {
            await _repo.UpdateAppointmentAsync(appointment);
            return appointment;
        }
    }
}
