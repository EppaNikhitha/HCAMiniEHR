using HCAMiniEHR.Models;
using HCAMiniEHR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HCAMiniEHR.Pages.LabOrders
{
    public class EditModel : PageModel
    {
        private readonly ILabOrderService _service;

        [BindProperty]
        public LabOrder LabOrder { get; set; }

        public EditModel(ILabOrderService service)
        {
            _service = service;
        }

        // GET: /LabOrders/Edit/{id}
        public async Task<IActionResult> OnGetAsync(int id)
        {
            // Fetch the LabOrder by its ID
            LabOrder = await _service.GetByIdAsync(id);

            // If the lab order is not found, return 404
            if (LabOrder == null)
            {
                return NotFound();
            }

            return Page();
        }

        // POST: /LabOrders/Edit/{id}
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page(); // If the model is invalid, reload the page to show errors
            }

            // Update the LabOrder via the service
            await _service.UpdateAsync(LabOrder);

            // After updating, redirect to the Index page
            return RedirectToPage("Index");
        }
    }
}
