using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Artsofte.Models
{
    public class ProgramingLanguage:Base
    {

        [Required]
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        
    }
}
