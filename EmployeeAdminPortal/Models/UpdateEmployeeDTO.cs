using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace EmployeeAdminPortal.Models
{
    public class UpdateEmployeeDTO
    {
        [Required]
        [MaxLength(100)]
        public required string Name { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public required string Address { get; set; }

        [MaxLength(100)]
        public string? Country { get; set; }

        [MaxLength(100)]
        public string? Phone { get; set; }

        [Required]
        [Precision(18, 2)]
        public decimal Salary { get; set; }

        [DisplayName("Employment Date")]
        public DateTime DateofEmployment { get; set; }
    }
}
