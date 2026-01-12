using HCAMiniEHR.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace HCAMiniEHR.Pages.Appointments
{
    public class DeleteModel : PageModel
    {
        private readonly HospitalDbContext _context;

        public DeleteModel(HospitalDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Appointment Appointment { get; set; }

        // GET: /Appointments/Delete/{id}
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Appointment = await _context.Appointments.FindAsync(id);

            if (Appointment == null)
            {
                return NotFound();
            }
            return Page();
        }

        // POST: /Appointments/Delete/{id}
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var appointmentToDelete = await _context.Appointments.FindAsync(id);

            if (appointmentToDelete != null)
            {
                _context.Appointments.Remove(appointmentToDelete);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
