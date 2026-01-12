using HCAMiniEHR.Models;
using HCAMiniEHR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HCAMiniEHR.Pages.Reports
{
    public class PendingLabOrdersModel : PageModel
    {
        private readonly ILabOrderService _service;
        public List<LabOrder> Orders { get; set; }

        public PendingLabOrdersModel(ILabOrderService service)
        {
            _service = service;
        }

        public async Task OnGetAsync()
        {
            Orders = (await _service.GetAllAsync()).Where(l => l.Status == "Pending").ToList();
        }
    }
}
