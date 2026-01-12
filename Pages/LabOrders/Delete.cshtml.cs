using HCAMiniEHR.Models;
using HCAMiniEHR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HCAMiniEHR.Pages.LabOrders
{
    public class DeleteModel : PageModel
    {
        private readonly ILabOrderService _service;

        [BindProperty]
        public LabOrder LabOrder { get; set; }

        public DeleteModel(ILabOrderService service)
        {
            _service = service;
        }

        public async Task OnGetAsync(int id)
        {
            LabOrder = await _service.GetByIdAsync(id);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _service.DeleteAsync(LabOrder.LabOrderId);
            return RedirectToPage("Index");
        }
    }
}
