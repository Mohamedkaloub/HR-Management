using System.ComponentModel.DataAnnotations;

namespace city.Models
{
    public class RetReason
    {
        [Key]
       public int id { get; set; }
        public string reason { get; set; }
        [Required]
        public int Emp_Code { get; set; }

    }
}
