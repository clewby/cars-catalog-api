using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SB.CarsCatalog.Api.Models
{
    /// <summary>
    /// Car Model
    /// </summary>
    [Table("Model")]
    public class Model
    {
        /// <summary>
        /// Model id
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Model title
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Model body style
        /// </summary>
        public BodyStyle BodyStyle { get; set; }
        /// <summary>
        /// Model power
        /// </summary>
        public int Power { get; set; }
        /// <summary>
        /// Model top speed
        /// </summary>
        public int TopSpeed { get; set; }

        /// <summary>
        /// Model brand id
        /// </summary>
        public int BrandId { get; set; }
        /// <summary>
        /// Model's Brand
        /// </summary>
        [JsonIgnore]
        public Brand Brand { get; set; }
    }
}
