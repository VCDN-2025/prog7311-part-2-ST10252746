using System.ComponentModel.DataAnnotations;

namespace PROG7311_POE_PART_2.Models
{
    public class FarmerViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string FullName { get; set; }

        public string FarmName { get; set; }
        public string Location { get; set; }
    }
}
