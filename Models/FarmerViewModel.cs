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
        public string FirstName { get; set; }

        [Required]
        public string Surname { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        public string FarmName { get; set; }

        public string FarmAddress { get; set; }

        public string FarmType { get; set; }
    }
}
