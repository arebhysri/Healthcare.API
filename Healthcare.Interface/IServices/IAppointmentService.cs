using Healthcare.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Interface.IServices
{
    public interface IAppointmentService
    {
        Task<Appointment> GetAppointmentById(int id);
        Task<IEnumerable<Appointment>> GetAllByPatient(int patientId);
        Task<Appointment> CreateAppointmentAsync(Appointment appointment);
        Task<Appointment> UpdateAppointmentAsync(Appointment appointment);
    }
}
