using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SB.CarsCatalog.Api.Models;

namespace SB.CarsCatalog.Api.Data
{
    /// <summary>
    /// Brand servise
    /// </summary>
    public class BrandService : IBrandService
    {
        /// <summary>
        /// Cars catalog context
        /// </summary>
        private readonly CarsCatalogDbContext context;

        /// <summary>
        /// Brands service constructor
        /// </summary>
        /// <param name="context">Cars catalog context</param>
        public BrandService(CarsCatalogDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Create new brand async
        /// </summary>
        /// <param name="brand">brand</param>
        /// <returns>created brand id</returns>
        public async Task<int> CreateAsync(Brand brand)
        {
            await context.Brands.AddAsync(brand);
            await context.SaveChangesAsync();
            return brand.Id.Value;
        }
        /// <summary>
        /// Delete specific brand by id async
        /// </summary>
        /// <param name="id">brand id</param>
        /// <returns>deleted items</returns>
        public async Task<int> DeleteAsync(int id)
        {
            context.Brands.Remove(new Brand() { Id = id });
            return await context.SaveChangesAsync();
        }
        /// <summary>
        /// Read specific brand by id async
        /// </summary>
        /// <param name="id">brand id</param>
        /// <returns>brand</returns>
        public async Task<Brand> ReadAsync(int id)
        {
            return await context.Brands
                            .Include(m => m.Models)
                            .FirstOrDefaultAsync(b => b.Id == id);
        }
        /// <summary>
        /// Read all brands async
        /// </summary>
        /// <returns>brands array</returns>
        public async Task<IEnumerable<Brand>> ReadAllAsync()
        {
            return await context.Brands
                .Include(m => m.Models)
                .ToArrayAsync(); 
        }
        /// <summary>
        /// Update specific brand async
        /// </summary>
        /// <param name="brand">brand to update</param>
        public async Task UpdateAsync(Brand brand)
        {
            context.Brands.Update(brand);
            await context.SaveChangesAsync();
        }
    }
}
