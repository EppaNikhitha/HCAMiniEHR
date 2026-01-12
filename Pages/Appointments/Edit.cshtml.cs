using HCAMiniEHR.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace HCAMiniEHR.Pages.Appointments
{
    public class EditModel : PageModel
    {
        private readonly HospitalDbContext _context;

        public EditModel(HospitalDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Appointment Appointment { get; set; }

        // GET: /Appointments/Edit/{id}
        public async Task<IActionResult> OnGetAsync(int id)
        {
            // Retrieve the appointment using FindAsync
            Appointment = await _context.Appointments
                .FirstOrDefaultAsync(a => a.AppointmentId == id);

            if (Appointment == null)
            {
                return NotFound(); // If the appointment doesn't exist
            }

            return Page(); // Return the page if appointment found
        }

        // POST: /Appointments/Edit/{id}
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page(); // If the model is not valid, reload the page with error messages
            }

            // Find the existing appointment to update
            var appointmentToUpdate = await _context.Appointments.FindAsync(id);

            if (appointmentToUpdate == null)
            {
                return NotFound(); // If appointment doesn't exist, return 404
            }

            // Update fields of the existing appointment
            appointmentToUpdate.AppointmentDate = Appointment.AppointmentDate;
            appointmentToUpdate.Reason = Appointment.Reason;

            try
            {
                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AppointmentExists(id))
                {
                    return NotFound(); // If appointment is not found after the update
                }
                else
                {
                    throw;
                }
            }

            // Redirect to the Index page after successful update
            return RedirectToPage("Index");
        }

        // Helper method to check if appointment exists
        private bool AppointmentExists(int id)
        {
            return _context.Appointments.Any(e => e.AppointmentId == id);
        }
    }
}
