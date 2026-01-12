using HCAMiniEHR.Models;
using HCAMiniEHR.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HCAMiniEHR.Services.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly HospitalDbContext _context;

        public AppointmentService(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task<List<Appointment>> GetAllAsync()
        {
            return await _context.Appointments
                .Include(a => a.Patient)
                .ToListAsync();
        }

        public async Task<Appointment> GetByIdAsync(int id)
        {
            return await _context.Appointments.FindAsync(id);
        }

        public async Task CreateAsync(Appointment appointment)
        {
            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Appointment appointment)
        {
            _context.Appointments.Update(appointment);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var appt = await _context.Appointments.FindAsync(id);
            if (appt != null)
            {
                _context.Appointments.Remove(appt);
                await _context.SaveChangesAsync();
            }
        }
    }
}
