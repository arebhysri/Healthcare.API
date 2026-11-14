using Healthcare.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Interface.IRepository
{
    public interface IAppointmentRepository
    {
        Task<Appointment> GetAppointmentById(int id);
        Task<IEnumerable<Appointment>> GetAllByPatient(int patientId);
        Task AddAppointmentAsync(Appointment appointment);
        Task UpdateAppointmentAsync(Appointment appointment);
    }
}
