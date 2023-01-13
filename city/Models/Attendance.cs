using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace city.Models
{
    public class Attendance
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double Days  { get; set; }
        [Required]
        public string Start_day { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");
        public string? Type { get; set; }
        public double Y_vacation { get; set; }
        public int EmployeeId { get; set; }
        [ValidateNever]
        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }
    }
}
