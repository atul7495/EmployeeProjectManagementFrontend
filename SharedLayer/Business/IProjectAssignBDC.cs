namespace SharedLayer.Business
{
    /// <summary>
    /// interface for project assigned business component
    /// </summary>
    public interface IProjectAssignBDC
    {
        OperationalResult<EmployeeListDTO> GetAssignEmp(int id);
        OperationalResult<EmployeeDTO[]> RemoveEmployee(int id, EmployeeDTO[] employeeDTO);
    }
}
