using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace city.Models
{
    public class Advance
    {
        [Key]
        public int Id { get; set; }
         [Required]
         public double Need { get; set; }
        [Required]
        public double Accept { get; set; }
        public string Date { get; set; }=DateTime.Now.ToString("dd/MM/yyyy");
        public int EmployeeId { get; set; }
        [ValidateNever]
        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }

    }
}
