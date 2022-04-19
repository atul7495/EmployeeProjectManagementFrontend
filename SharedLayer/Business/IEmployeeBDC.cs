namespace SharedLayer.Business
{
    /// <summary>
    /// interface for employee business component
    /// </summary>
    public interface IEmployeeBDC
    {
        OperationalResult<EmployeeDTO> CreateEmployee(EmployeeDTO employeeDTO);

        OperationalResult<EmployeeListDTO> EmployeeList();

        OperationalResult<EmployeeDTO> EditEmployee(EmployeeDTO employeeDTO);
        OperationalResult<EmployeeDTO> DeleteEmployee(EmployeeDTO employeeDTO);

        OperationalResult<EmployeeDTO> UpdateEmployee(EmployeeDTO employeeDTO);

        OperationalResult<ProjectDTO[]> AssignProject(int id, ProjectDTO[] projectDTO);
        OperationalResult<EmployeeListDTO> GetAssignProject(int id);

    }
}
