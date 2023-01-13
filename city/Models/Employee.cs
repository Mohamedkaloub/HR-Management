using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace city.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "يجب ادخال كود الموظف")]
        public int Emp_code { get; set; }
        [Required(ErrorMessage = "يجب ادخال اسم الموظف")]
        public string Name { get; set; }
        [Required(ErrorMessage = "يجب ادخال العنوان")]
        public string Address { get; set; }
        [Required(ErrorMessage = "يجب ادخال الرقم القومي")]
        public string Nat_id { get; set; }
        [Required(ErrorMessage = "يجب ادخال المؤهل")]
        public string Qualif { get; set; }
        [Required(ErrorMessage = "يجب ادخال تاريخ التعيين")]
        public DateTime Hire_date { get; set; }
        [ValidateNever]
        public DateTime ? Ret_date { get; set; }
        [Required]
        public int JobId { get; set; }
        [ForeignKey("JobId")]
        [ValidateNever]
        public Job job { get; set; }
        
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        [ValidateNever]
        public Department department { get; set; }
        public int ManagmentId { get; set; }

        [ForeignKey("ManagmentId")]
        [ValidateNever]
        public Management Management { get; set; }
        public int SectionId { get; set; }

        [ForeignKey("SectionId")]
        [ValidateNever]
        public Section Section { get; set; }

         public string ?Manager { get; set; }
        [MaxLength(25)]
         public string Shift { get; set; }
    }
}
