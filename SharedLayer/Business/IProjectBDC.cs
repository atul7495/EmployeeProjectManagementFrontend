namespace SharedLayer.Business
{
    /// <summary>
    /// interface for project business component
    /// </summary>
    public interface IProjectBDC
    {
        OperationalResult<ProjectDTO> CreateProject(ProjectDTO projectDTO);
        OperationalResult<ProjectListDTO> ProjectList();
        OperationalResult<ProjectDTO> DeleteProject(ProjectDTO projectDTO);

        OperationalResult<ProjectDTO> EditProject(ProjectDTO projectDTO);
        OperationalResult<ProjectDTO> UpdateProject(ProjectDTO projectDTO);

    }
}
