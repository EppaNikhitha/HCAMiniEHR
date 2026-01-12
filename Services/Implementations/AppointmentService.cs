//using HCAMiniEHR.Models;
//using HCAMiniEHR.Services.Interfaces;
//using Microsoft.EntityFrameworkCore;

//namespace HCAMiniEHR.Services.Implementations
//{
//    public class AppointmentService : IAppointmentService
//    {
//        private readonly HospitalDbContext _context;

//        public AppointmentService(HospitalDbContext context)
//        {
//            _context = context;
//        }

//        public async Task<List<Appointment>> GetAllAsync()
//        {
//            return await _context.Appointments
//                .Include(a => a.Patient)
//                .ToListAsync();
//        }

//        public async Task<Appointment> GetByIdAsync(int id)
//        {
//            return await _context.Appointments.FindAsync(id);
//        }

//        public async Task CreateAsync(Appointment appointment)
//        {
//            _context.Appointments.Add(appointment);
//            await _context.SaveChangesAsync();
//        }

//        public async Task UpdateAsync(Appointment appointment)
//        {
//            _context.Appointments.Update(appointment);
//            await _context.SaveChangesAsync();
//        }

//        public async Task DeleteAsync(int id)
//        {
//            var appt = await _context.Appointments.FindAsync(id);
//            if (appt != null)
//            {
//                _context.Appointments.Remove(appt);
//                await _context.SaveChangesAsync();
//            }
//        }

//    }
//}

using HCAMiniEHR.Models;
using HCAMiniEHR.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

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

        // Here is the modified method to call the stored procedure
        public async Task CreateAsync(Appointment appointment)
        {
            // Create parameters for the stored procedure
            var patientIdParam = new SqlParameter("@PatientId", appointment.PatientId);
            var appointmentDateParam = new SqlParameter("@AppointmentDate", appointment.AppointmentDate);
            var reasonParam = new SqlParameter("@Reason", appointment.Reason);

            // Execute the stored procedure using ExecuteSqlRawAsync
            await _context.Database.ExecuteSqlRawAsync(
                "EXEC Healthcare.CreateAppointment @PatientId, @AppointmentDate, @Reason",
                patientIdParam, appointmentDateParam, reasonParam);
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
