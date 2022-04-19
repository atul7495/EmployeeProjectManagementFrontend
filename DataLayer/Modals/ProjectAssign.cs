using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    public class ProjectAssign
    {
        [Key]
        public int ProjAssignId { get; set; }

        [ForeignKey("EmployeeModal")]
        public int RefEmpId { get; set; }
        public EmployeeModal EmployeeModal { get; set; }

        [ForeignKey("ProjectModal")]
        public int RefProjId { get; set; }

        public ProjectModal ProjectModal { get; set; }
    }
}
