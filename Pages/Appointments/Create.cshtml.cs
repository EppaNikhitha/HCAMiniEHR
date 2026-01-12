using HCAMiniEHR.Models;
using HCAMiniEHR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HCAMiniEHR.Pages.Appointments
{
    public class CreateModel : PageModel
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;

        public SelectList PatientList { get; set; }

        [BindProperty]
        public Appointment Appointment { get; set; }

        public CreateModel(IAppointmentService appointmentService, IPatientService patientService)
        {
            _appointmentService = appointmentService;
            _patientService = patientService;
        }

        public async Task OnGetAsync()
        {
            PatientList = new SelectList(await _patientService.GetAllAsync(), "PatientId", "FullName");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _appointmentService.CreateAsync(Appointment);
            return RedirectToPage("Index");
        }
    }
}
