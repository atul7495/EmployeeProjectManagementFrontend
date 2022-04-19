using System.Collections.Generic;

namespace SharedLayer
{
    /// <summary>
    /// data trasnfer object for project assing comoponent
    /// </summary>
    public class ProjectAssignDTO
    {
        public List<ProjectDTO> ProjectDTOs { get; set; }
        public int RefEmpId { get; set; }

        public int RefProjId { get; set; }
    }
}
