using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AgriEnergyConnect.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Category { get; set; }

        public string ProductURL { get; set; }

        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }

        // Foreign Key
        [ForeignKey("Farmer")]
        public int FarmerId { get; set; }

        // Navigation Property
        public virtual Farmer Farmer { get; set; }
    }
}
