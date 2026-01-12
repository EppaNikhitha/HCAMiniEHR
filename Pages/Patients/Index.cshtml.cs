using HCAMiniEHR.Models;
using HCAMiniEHR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HCAMiniEHR.Pages.Patients
{
    public class IndexModel : PageModel
    {
        private readonly IPatientService _service;

        public List<Patient> Patients { get; set; } = new();

        public IndexModel(IPatientService service)
        {
            _service = service;
        }

        public async Task OnGetAsync()
        {
            Patients = await _service.GetAllAsync();
        }
    }
}
