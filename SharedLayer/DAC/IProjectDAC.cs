namespace SharedLayer.DAC
{
    /// <summary>
    /// interface for project data access component
    /// </summary>
    public interface IProjectDAC
    {
        ProjectDTO CreateProject(ProjectDTO projectDTO);

        ProjectListDTO ProjectList();

        ProjectDTO DeleteProject(ProjectDTO projectDTO);

        ProjectDTO EditProject(ProjectDTO projectDTO);
        ProjectDTO UpdateProject(ProjectDTO projectDTO);
    }
}
