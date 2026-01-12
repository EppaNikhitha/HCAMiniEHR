using HCAMiniEHR.Models;
using HCAMiniEHR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HCAMiniEHR.Pages.LabOrders
{
    public class CreateModel : PageModel
    {
        private readonly ILabOrderService _labService;
        private readonly IAppointmentService _apptService;

        public SelectList AppointmentList { get; set; }

        [BindProperty]
        public LabOrder LabOrder { get; set; }

        public CreateModel(ILabOrderService labService, IAppointmentService apptService)
        {
            _labService = labService;
            _apptService = apptService;
        }

        public async Task OnGetAsync()
        {
            AppointmentList = new SelectList(await _apptService.GetAllAsync(), "AppointmentId", "AppointmentId");
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _labService.CreateAsync(LabOrder);
            return RedirectToPage("Index");
        }
    }
}
