using Healthcare.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Interface.IServices
{
    public interface IPatientService
    {
        Task<Patient> GetPatientById(int id);
        Task<IEnumerable<Patient>> GetAllPatients();
        Task<Patient> CreatePatientAsync(Patient patient);
        Task<Patient> UpdatePatientAsync(Patient patient);
    }
}
