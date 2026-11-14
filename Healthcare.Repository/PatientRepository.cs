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
    public class PatientRepository : IPatientRepository
    {
        private readonly HealthCareDbContext _context;

        public PatientRepository(HealthCareDbContext healthCareDbContext)
        {
            _context =healthCareDbContext;
        }
        public Task AddPatientAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            return _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsAsync()
            => await _context.Patients.ToListAsync();

        public Task<Patient> GetPatientByIdAsync(int id)
            => _context.Patients.FirstOrDefaultAsync(p => p.Id == id);

        public Task UpdatePatientAsync(Patient patient)
        {
            _context.Patients.Update(patient);
            return _context.SaveChangesAsync();
        }
    }
}
