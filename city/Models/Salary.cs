using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace city.Models
{
    public class Salary
    {
        [Key]
        public int Id { get; set; }
        public double Total { get; set; }
        public string time { get; set; } = DateTime.Now.ToString("dd/MM/yyyy");
        public double punishment { get; set; }

        public int EmployeeId { get; set; }
        [ValidateNever]
        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }
    }
}
