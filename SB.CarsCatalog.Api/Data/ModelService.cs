using Microsoft.EntityFrameworkCore;
using SB.CarsCatalog.Api.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SB.CarsCatalog.Api.Data
{
    /// <summary>
    /// Model servise
    /// </summary>
    public class ModelService : IModelService
    {
        /// <summary>
        /// Cars catalog context
        /// </summary>
        private readonly CarsCatalogDbContext context;

        /// <summary>
        /// Models service constructor
        /// </summary>
        /// <param name="context">Cars catalog context</param>
        public ModelService(CarsCatalogDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Create new model async
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>created model id</returns>
        public async Task<int> CreateAsync(Model model)
        {
            await context.Models.AddAsync(model);
            await context.SaveChangesAsync();
            return model.Id;
        }
        /// <summary>
        /// Delete specific model by id async
        /// </summary>
        /// <param name="model id">model id</param>
        /// <returns>deleted items</returns>
        public async Task<int> DeleteAsync(int id)
        {
            context.Models.Remove(new Model() { Id = id });
            return await context.SaveChangesAsync();
        }
        /// <summary>
        /// Read all models for specific brand async
        /// </summary>s
        /// <returns>models array</returns>
        public async Task<IEnumerable<Model>> ReadAllAsync(int brandId)
        {
            return await context.Models
                .Where(m => m.BrandId == brandId)
                .ToArrayAsync();
        }
        /// <summary>
        /// Read specific model by id async
        /// </summary>s
        /// <param name="id">model id</param>
        /// <returns>model</returns>
        public async Task<Model> ReadAsync(int id)
        {
            return await context.Models
                .FirstOrDefaultAsync(m => m.Id == id); 
        }
        /// <summary>
        /// Update specific model async
        /// </summary>
        /// <param name="model">model to update</param>
        public async Task UpdateAsync(Model model)
        {
            context.Models.Update(model);
            await context.SaveChangesAsync();
        }
    }
}
