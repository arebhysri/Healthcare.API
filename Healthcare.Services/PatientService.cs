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
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _repo;

        public PatientService(IPatientRepository patientRepository)
        {
            _repo = patientRepository;
        }
        public async Task<Patient> CreatePatientAsync(Patient patient)
        {
            if (string.IsNullOrWhiteSpace(patient.FullName))
            {
                throw new Exception("Patient name is required");
            }

            patient.Id = 0;
            await _repo.AddPatientAsync(patient);
            return new Patient
            {
                Id = patient.Id,
                FullName = patient.FullName,
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender,
                Address = patient.Address,
                PhoneNumber = patient.PhoneNumber,
                Email = patient.Email
            };
        }

        public Task<IEnumerable<Patient>> GetAllPatients()
            => _repo.GetAllPatientsAsync();

        public Task<Patient> GetPatientById(int id)
            => _repo.GetPatientByIdAsync(id);

        public async Task<Patient> UpdatePatientAsync(Patient patient)
        {
            await _repo.UpdatePatientAsync(patient);
            return patient;
        }
    }
}
