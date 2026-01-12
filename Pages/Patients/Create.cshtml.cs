using HCAMiniEHR.Models;
using HCAMiniEHR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HCAMiniEHR.Pages.Patients
{
    public class CreateModel : PageModel
    {
        private readonly IPatientService _service;

        [BindProperty]
        public Patient Patient { get; set; }

        public CreateModel(IPatientService service)
        {
            _service = service;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.CreateAsync(Patient);
            return RedirectToPage("Index");
        }
    }
}
