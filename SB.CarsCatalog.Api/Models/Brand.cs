using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SB.CarsCatalog.Api.Models
{
    /// <summary>
    /// Car Brand
    /// </summary>
    [Table("Brand")]
    public class Brand
    {
        /// <summary>
        /// Brand id
        /// </summary>
        [Key]
        public int? Id { get; set; }
        /// <summary>
        /// Brand title
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// Brand founded
        /// </summary>
        [Required]
        public int Founded { get; set; }
        /// <summary>
        /// Brand founder
        /// </summary>
        [Required]
        public string Founder { get; set; }
        /// <summary>
        /// Brand headquarters
        /// </summary>
        [Required]
        public string Headquarters { get; set; }
        /// <summary>
        /// Brand overview
        /// </summary>
        public string Overview { get; set; }
        /// <summary>
        /// Brand's models
        /// </summary>
        public ICollection<Model> Models { get; set; }
    }
}
