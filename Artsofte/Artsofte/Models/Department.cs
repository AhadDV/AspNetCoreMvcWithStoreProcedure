using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Artsofte.Models
{
    public class Department:Base
    {
        [Required]
        public byte Floor { get; set; }
        public List<ProgramingLanguage> ProgramingLanguages { get; set; }
        public List<Employee> Employes { get; set; }

    }
}
