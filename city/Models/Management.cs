using System.ComponentModel.DataAnnotations;

namespace city.Models
{
    public class Management
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "please enter the name")]
       public string Name { get; set; } 
     
    
    }
}
