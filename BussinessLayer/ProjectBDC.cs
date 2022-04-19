using DataLayer.DataAccessComponents;
using SharedLayer;
using SharedLayer.Business;
using System;

namespace BussinessLayer
{

    /// <summary>
    /// business domain component for the project
    /// </summary>
    public class ProjectBDC : IProjectBDC
    {
        /// <summary>
        /// method for creating project in business component
        /// </summary>
        /// <param name="projectDTO"></param>
        /// <returns> success,failure and exception result</returns>
        public OperationalResult<ProjectDTO> CreateProject(ProjectDTO projectDTO)
        {
            OperationalResult<ProjectDTO> retval = null;
            try
            {
                ProjectDAC projectDAC = new ProjectDAC();
                projectDAC.CreateProject(projectDTO);
                if (projectDAC != null)
                {
                    retval = OperationalResult<ProjectDTO>.successResult(projectDTO);

                }
                else
                {
                    retval = OperationalResult<ProjectDTO>.failureResult("failed");
                }
            }
            catch (Exception ex)
            {
                retval = OperationalResult<ProjectDTO>.errorResult(ex.Message, ex.StackTrace);
            }
            return retval;
        }

        /// <summary>
        /// method for delete project in business component
        /// </summary>
        /// <param name="projectDTO"></param>
        /// <returns>success,failure and exception result</returns>
        public OperationalResult<ProjectDTO> DeleteProject(ProjectDTO projectDTO)
        {
            OperationalResult<ProjectDTO> retval = null;
            try
            {
                ProjectDAC projectDAC = new ProjectDAC();
                projectDAC.DeleteProject(projectDTO);
                if (projectDAC != null)
                {
                    retval = OperationalResult<ProjectDTO>.successResult(projectDTO);

                }
                else
                {
                    retval = OperationalResult<ProjectDTO>.failureResult("failed");
                }
            }
            catch (Exception ex)
            {
                retval = OperationalResult<ProjectDTO>.errorResult(ex.Message, ex.StackTrace);
            }
            return retval;
        }

        /// <summary>
        /// method for edit project in business component
        /// </summary>
        /// <param name="projectDTO"></param>
        /// <returns>success,failure and exception result</returns>
        public OperationalResult<ProjectDTO> EditProject(ProjectDTO projectDTO)
        {
            OperationalResult<ProjectDTO> retval = null;
            try
            {
                ProjectDAC projectDAC = new ProjectDAC();
                projectDAC.EditProject(projectDTO);
                if (projectDAC != null)
                {
                    retval = OperationalResult<ProjectDTO>.successResult(projectDTO);

                }
                else
                {
                    retval = OperationalResult<ProjectDTO>.failureResult("failed");
                }
            }
            catch (Exception ex)
            {
                retval = OperationalResult<ProjectDTO>.errorResult(ex.Message, ex.StackTrace);
            }
            return retval;
        }

        /// <summary>
        /// method for getting project list in business component
        /// </summary>
        /// <returns>success,failure and exception result</returns>
        public OperationalResult<ProjectListDTO> ProjectList()
        {
            OperationalResult<ProjectListDTO> retval = null;
            try
            {
                ProjectDAC projectDAC = new ProjectDAC();
                var result = projectDAC.ProjectList();
                if (result != null)
                {
                    retval = OperationalResult<ProjectListDTO>.successResult(result);

                }
                else
                {
                    retval = OperationalResult<ProjectListDTO>.failureResult("failed");
                }
            }
            catch (Exception ex)
            {
                retval = OperationalResult<ProjectListDTO>.errorResult(ex.Message, ex.StackTrace);
            }
            return retval;
        }

        /// <summary>
        /// method for updating project in business component
        /// </summary>
        /// <param name="projectDTO"></param>
        /// <returns>success,failure and exception result</returns>
        public OperationalResult<ProjectDTO> UpdateProject(ProjectDTO projectDTO)
        {
            OperationalResult<ProjectDTO> retval = null;
            try
            {
                ProjectDAC projectDAC = new ProjectDAC();
                projectDAC.UpdateProject(projectDTO);
                if (projectDAC != null)
                {
                    retval = OperationalResult<ProjectDTO>.successResult(projectDTO);

                }
                else
                {
                    retval = OperationalResult<ProjectDTO>.failureResult("failed");
                }
            }
            catch (Exception ex)
            {
                retval = OperationalResult<ProjectDTO>.errorResult(ex.Message, ex.StackTrace);
            }
            return retval;
        }
    }
}
