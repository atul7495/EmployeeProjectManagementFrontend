using System.Data.Entity;

namespace DataLayer.Modals
{
    /// <summary>
    /// database context
    /// </summary>
    public class ManagementContext : DbContext
    {
        public ManagementContext() : base("name=ManagementEvent") // name of the database table
        {
        }

        /// <summary>
        /// database set for all the table
        /// </summary>
        public DbSet<EmployeeModal> Employee { get; set; }
        public DbSet<ProjectModal> Project { get; set; }
        public DbSet<ProjectAssign> ProjectAssigns { get; set; }
    }
}
