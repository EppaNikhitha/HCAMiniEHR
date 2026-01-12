using HCAMiniEHR.Models;
using HCAMiniEHR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HCAMiniEHR.Pages.LabOrders
{
    public class IndexModel : PageModel
    {
        private readonly ILabOrderService _service;
        public List<LabOrder> LabOrders { get; set; } = new();

        public IndexModel(ILabOrderService service)
        {
            _service = service;
        }

        public async Task OnGetAsync()
        {
            LabOrders = await _service.GetAllAsync();
        }
    }
}
