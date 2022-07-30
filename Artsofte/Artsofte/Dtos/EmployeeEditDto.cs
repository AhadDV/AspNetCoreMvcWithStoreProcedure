using System.ComponentModel.DataAnnotations;

namespace Artsofte.Dtos
{
    public class EmployeeEditDto
    {

        [Required]
        [StringLength(30)]
        public string EmployeeName { get; set; }
        [Required]
        [StringLength(30)]
        public string EmployeeSurname { get; set; }
        [Required]
        [Range(18, 80)]
        public byte EmployeeAge { get; set; }
        [Required]
        [StringLength(20)]
        public string EmployeeGender { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        [Required]
        public int ProgrammingLanguageId { get; set; }
        public string DepartmentName { get; set; }
        public string ProgrammingLanguageName { get; set; }
    }
}
