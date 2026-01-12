using HCAMiniEHR.Models;

namespace HCAMiniEHR.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<List<Appointment>> GetAllAsync();
        Task<Appointment> GetByIdAsync(int id);
        Task CreateAsync(Appointment appointment);
        Task UpdateAsync(Appointment appointment);
        Task DeleteAsync(int id);
    }
}
