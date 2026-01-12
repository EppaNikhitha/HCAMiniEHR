using HCAMiniEHR.Models;
using HCAMiniEHR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HCAMiniEHR.Pages.Patients
{
    public class EditModel : PageModel
    {
        private readonly IPatientService _service;

        [BindProperty]
        public Patient Patient { get; set; }

        public EditModel(IPatientService service)
        {
            _service = service;
        }

        public async Task OnGetAsync(int id)
        {
            Patient = await _service.GetByIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.UpdateAsync(Patient);
            return RedirectToPage("Index");
        }
    }
}
