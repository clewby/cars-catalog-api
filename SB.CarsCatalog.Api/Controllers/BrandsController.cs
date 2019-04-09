using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SB.CarsCatalog.Api.Data;
using SB.CarsCatalog.Api.Errors;
using SB.CarsCatalog.Api.Models;
using System.Net;
using System.Threading.Tasks;

namespace SB.CarsCatalog.Api.Controllers
{
    /// <summary>
    /// Brands api controller
    /// </summary>
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        /// <summary>
        /// Brand service
        /// </summary>
        private readonly IBrandService brandService;

        /// <summary>
        /// Brands controller ctor
        /// </summary>
        /// <param name="brandService">brand service</param>
        public BrandsController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        /// <summary>
        /// Get all brands
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetBrands()
        {
            var brands = await brandService.ReadAllAsync();
            return Ok(brands);
        }
        /// <summary>
        /// Get specific brand
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>specific brand</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrand(int id)
        {
            var brand = await brandService.ReadAsync(id);
            return Ok(brand);
        }
        /// <summary>
        /// Add a new brand
        /// </summary>
        /// <param name="brand">brand</param>
        /// <returns>number of created items</returns>
        [HttpPost]
        public async Task<IActionResult> AddBrand([FromBody]Brand brand)
        {
            if (ModelState.IsValid)
            {
                var brandId = await brandService.CreateAsync(brand);
                return Ok(brandId);
            }

            throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Brand data is incorrect");
        }
        /// <summary>
        /// Delete specific brand
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>number of deleted brands</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            int result = await brandService.DeleteAsync(id);
            if (result == 0)
            {
                return NotFound();
            }
            return Ok(result);
        }
        /// <summary>
        /// Update brand
        /// </summary>
        /// <param name="brand">brand</param>
        [HttpPut]
        public async Task<IActionResult> UpdateBrand([FromBody]Brand brand)
        {
            if (ModelState.IsValid)
            {
                await brandService.UpdateAsync(brand);
                return Ok();
            }

            throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Brand data is incorrect");
        }
    }
}