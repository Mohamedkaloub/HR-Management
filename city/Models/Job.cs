using System.ComponentModel.DataAnnotations;

namespace city.Models
{
    public class Job
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "please enter the name")]
       public string Name { get; set; } 
        [Required]
        public int number { get; set; }
        
    }
}
