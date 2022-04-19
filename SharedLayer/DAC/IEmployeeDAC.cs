namespace SharedLayer
{

    /// <summary>
    /// interface for employee data access component
    /// </summary>
    public interface IEmployeeDAC
    {
        EmployeeDTO CreateEmployee(EmployeeDTO employeeDTO);

        EmployeeListDTO EmployeeListDTO();

        EmployeeDTO EditEmployee(EmployeeDTO employeeDTO);

        EmployeeDTO DeleteEmployee(EmployeeDTO employeeDTO);

        EmployeeDTO UpdateEmployee(EmployeeDTO employeeDTO);

        ProjectDTO[] AssignProject(int id, ProjectDTO[] projectDTO);

        EmployeeListDTO AssignProjectList(int id);
    }
}
