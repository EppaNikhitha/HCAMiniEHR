using HCAMiniEHR.Models;
using HCAMiniEHR.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HCAMiniEHR.Pages.Appointments
{
    public class IndexModel : PageModel
    {
        private readonly IAppointmentService _service;

        public List<Appointment> Appointments { get; set; } = new();

        public IndexModel(IAppointmentService service)
        {
            _service = service;
        }

        public async Task OnGetAsync()
        {
            Appointments = await _service.GetAllAsync();
        }
    }
}
