using HCAMiniEHR.Models;
using HCAMiniEHR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HCAMiniEHR.Pages.Reports
{
    public class PatientsWithoutFollowUpModel : PageModel
    {
        private readonly IPatientService _service;
        public List<Patient> Patients { get; set; }

        public PatientsWithoutFollowUpModel(IPatientService service)
        {
            _service = service;
        }

        public async Task OnGetAsync()
        {
            var all = await _service.GetAllAsync();
            Patients = all.Where(p => !p.Appointments.Any(a => a.AppointmentDate > DateTime.Now)).ToList();
        }
    }
}
