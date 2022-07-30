using System.ComponentModel.DataAnnotations;

namespace Artsofte.Models
{
    public class Employee:Base
    {
        [Required]
        public string Surname { get; set; }
        [Required]
        public byte Age { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int? DepartmentId { get; set; }
        public Department Department { get; set; }

        public int? ProgramingLanguageId { get; set; }
        public ProgramingLanguage ProgramingLanguage { get; set; }

    }
}
