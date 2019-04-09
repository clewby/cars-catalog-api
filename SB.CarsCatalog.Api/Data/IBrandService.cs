using SB.CarsCatalog.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SB.CarsCatalog.Api.Data
{
    /// <summary>
    /// Brand service interface
    /// </summary>
    public interface IBrandService
    {
        /// <summary>
        /// Create new brand async
        /// </summary>
        /// <param name="brand">brand</param>
        /// <returns>created brand id</returns>
        Task<int> CreateAsync(Brand brand);
        /// <summary>
        /// Read specific brand by id async
        /// </summary>
        /// <param name="id">brand id</param>
        /// <returns>brand</returns>
        Task<Brand> ReadAsync(int id);
        /// <summary>
        /// Read all brands async
        /// </summary>
        /// <returns>brands array</returns>
        Task<IEnumerable<Brand>> ReadAllAsync();
        /// <summary>
        /// Update specific brand async
        /// </summary>
        /// <param name="brand">brand to update</param>
        Task UpdateAsync(Brand brand);
        /// <summary>
        /// Delete specific brand by id async
        /// </summary>
        /// <param name="id">brand id</param>
        /// <returns>deleted items</returns>
        Task<int> DeleteAsync(int id);
    }
}
