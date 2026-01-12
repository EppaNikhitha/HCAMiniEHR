using HCAMiniEHR.Models;
using HCAMiniEHR.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HCAMiniEHR.Services.Implementations
{
    public class PatientService : IPatientService
    {
        private readonly HospitalDbContext _context;

        public PatientService(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            return await _context.Patients
                .Include(p => p.Appointments)
                .ToListAsync();
        }

        public async Task<Patient> GetByIdAsync(int id)
        {
            return await _context.Patients.FindAsync(id);
        }

        public async Task CreateAsync(Patient patient)
        {
            _context.Patients.Add(patient);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Patient patient)
        {
            _context.Patients.Update(patient);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var patient = await _context.Patients.FindAsync(id);
            if (patient != null)
            {
                _context.Patients.Remove(patient);
                await _context.SaveChangesAsync();
            }
        }
    }
}
