namespace SharedLayer.DAC
{
    /// <summary>
    /// interface for project assigned data access component
    /// </summary>
    public interface IProjectAssignDAC
    {
        EmployeeListDTO GetAssignEmp(int id);

        EmployeeDTO[] RemoveEmployee(int id, EmployeeDTO[] employeeDTOs);
    }
}
