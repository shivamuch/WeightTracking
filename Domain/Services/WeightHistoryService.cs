using Domain.DataContext;
using Domain.DomainClasses;
using Domain.IService;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services
{
    /// <summary>
    /// Inject the DbContext as constructor injectation
    /// </summary>
    public class WeightHistoryService : IWeightHistoryService
    {
        private readonly WeightDbContext ctx;
        public WeightHistoryService(WeightDbContext ctx)
        {
            this.ctx = ctx;
        }
        /// <summary>
        /// async: The method will be containing the Asynchronous call
        /// and this method returns Task Object
        /// await: The statement performs Async operation on separate thread
        /// other than calling thread and the async method will returns response
        /// to the calling thread
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<WeightHistory> CreateAsync(WeightHistory entity)
        {
            // new Weight will be added in DbSet
            var result = await ctx.WeightHistory.AddAsync(entity);
            // the transaction will be commited by adding new Weight in
            // Categories table
            await ctx.SaveChangesAsync();
            // newly created Weight will be returned
            return result.Entity;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            // seacrh record based on Primary key
            var cat = await ctx.WeightHistory.FindAsync(id);
            if (cat != null)
            {
                // remove the object
                ctx.WeightHistory.Remove(cat);
                await ctx.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<WeightHistory>> GetAsync()
        {
            return await ctx.WeightHistory.ToListAsync();
        }

        public async Task<WeightHistory> GetAsync(int id)
        {
            return await ctx.WeightHistory.FindAsync(id);
        }

        public async Task<WeightHistory> UpdateAsync(int id, WeightHistory entity)
        {
            // seacrh record based on Primary key
            var cat = await ctx.WeightHistory.FindAsync(id);
            if (cat != null)
            {
                cat.Value = entity.Value;
                cat.Id = cat.Id;
                cat.Fk_UserId = cat.Fk_UserId;
                await ctx.SaveChangesAsync();
            }
            return cat;
        }
    }
}
