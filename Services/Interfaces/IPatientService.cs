using HCAMiniEHR.Models;

namespace HCAMiniEHR.Services.Interfaces
{
    public interface IPatientService
    {
        Task<List<Patient>> GetAllAsync();
        Task<Patient> GetByIdAsync(int id);
        Task CreateAsync(Patient patient);
        Task UpdateAsync(Patient patient);
        Task DeleteAsync(int id);
    }
}
