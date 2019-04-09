using SB.CarsCatalog.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SB.CarsCatalog.Api.Data
{
    /// <summary>
    /// Model service interface
    /// </summary>
    public interface IModelService
    {
        /// <summary>
        /// Create new model async
        /// </summary>
        /// <param name="model">model</param>
        /// <returns>created model id</returns>
        Task<int> CreateAsync(Model model);
        /// <summary>
        /// Read specific model by id async
        /// </summary>s
        /// <param name="id">model id</param>
        /// <returns>model</returns>
        Task<Model> ReadAsync(int id);
        /// <summary>
        /// Read all models for specific brand async
        /// </summary>s
        /// <returns>models array</returns>
        Task<IEnumerable<Model>> ReadAllAsync(int brandId);
        /// <summary>
        /// Update specific model async
        /// </summary>
        /// <param name="model">model to update</param>
        Task UpdateAsync(Model model);
        /// <summary>
        /// Delete specific model by id async
        /// </summary>
        /// <param name="model">model id</param>
        /// <returns>deleted items</returns>
        Task<int> DeleteAsync(int id);
    }
}
