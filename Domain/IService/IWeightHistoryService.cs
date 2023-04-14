using Domain.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IService
{
    public interface IWeightHistoryService
    {
        Task<WeightHistory> CreateAsync(WeightHistory entity);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<WeightHistory>> GetAsync();
        Task<WeightHistory> GetAsync(int id);
        Task<WeightHistory> UpdateAsync(int id, WeightHistory entity);
    }
}
