using HCAMiniEHR.Models;
using HCAMiniEHR.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HCAMiniEHR.Services.Implementations
{
    public class LabOrderService : ILabOrderService
    {
        private readonly HospitalDbContext _context;

        public LabOrderService(HospitalDbContext context)
        {
            _context = context;
        }

        public async Task<List<LabOrder>> GetAllAsync()
        {
            return await _context.LabOrders
                .Include(l => l.Appointment)
                .ToListAsync();
        }

        public async Task<LabOrder> GetByIdAsync(int id)
        {
            return await _context.LabOrders.FindAsync(id);
        }

        public async Task CreateAsync(LabOrder order)
        {
            _context.LabOrders.Add(order);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(LabOrder order)
        {
            _context.LabOrders.Update(order);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var lab = await _context.LabOrders.FindAsync(id);
            if (lab != null)
            {
                _context.LabOrders.Remove(lab);
                await _context.SaveChangesAsync();
            }
        }
    }
}
