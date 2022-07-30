namespace Artsofte.Models
{
    public class EmployeeDataFromDb
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeSurname { get; set; }
        public byte EmployeeAge { get; set; }
        public string EmployeeGender { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentId { get; set; }
        public string ProgrammingLanguageName { get; set; }
        public int ProgrammingLanguageId { get; set; }
    }
}
