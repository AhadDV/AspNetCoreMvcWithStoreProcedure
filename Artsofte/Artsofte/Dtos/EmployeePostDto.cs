using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace Artsofte.Dtos
{
    public class EmployeePostDto
    {
        [Required]
        [StringLength(30)]
        public string Name { get; set; }
        [Required]
        [StringLength(30)]
        public string Surname { get; set; }
        [Required]
        [Range(18,80)]
        public byte Age { get; set; }
        [Required]
        [StringLength(20)]
        public string Gender { get; set; }
       
        [Required (ErrorMessage ="Department Name is Required")]
        public int DepartmentId { get; set; }
        [Required]
        public int ProgrammingLanguageId { get; set; }
    }


}
