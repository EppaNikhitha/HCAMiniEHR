using HCAMiniEHR.Models;

namespace HCAMiniEHR.Services.Interfaces
{
    public interface ILabOrderService
    {
        Task<List<LabOrder>> GetAllAsync();
        Task<LabOrder> GetByIdAsync(int id);
        Task CreateAsync(LabOrder order);
        Task UpdateAsync(LabOrder order);
        Task DeleteAsync(int id);
    }
}
