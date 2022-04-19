using System.Collections.Generic;

namespace SharedLayer
{
    /// <summary>
    /// employe list DTO
    /// </summary>
    public class EmployeeListDTO
    {
        public List<EmployeeDTO> EmployeeList { get; set; }
        public List<string> AssignProjectList { get; set; }
    }
}
