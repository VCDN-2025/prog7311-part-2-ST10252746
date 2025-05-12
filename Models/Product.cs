using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PROG7311_POE_PART_2.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ProductionDate { get; set; }

        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Cost { get; set; }

        public int LifespanYears { get; set; }
        public string Manufacturer { get; set; }


        // Foreign key
        [ForeignKey("Farmer")]
        public int FarmerId { get; set; }
        public Farmer Farmer { get; set; }
    }

}
