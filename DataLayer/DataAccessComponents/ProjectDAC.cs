using AutoMapper;
using DataLayer.Modals;
using SharedLayer;
using SharedLayer.DAC;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.DataAccessComponents
{
    public class ProjectDAC : IProjectDAC
    {
        /// <summary>
        /// method for creating new project
        /// </summary>
        /// <param name="projectDTO"></param>
        /// <returns>new created project</returns>
        public ProjectDTO CreateProject(ProjectDTO projectDTO)
        {
            ProjectDTO retVal = null;
            try
            {
                using (ManagementContext dbContext = new ManagementContext())
                {
                    ProjectModal projectModal = new ProjectModal
                    {
                        Pname = projectDTO.pname,
                        Pdetail = projectDTO.pdetail,
                        Pdate = projectDTO.pdate
                    };
                    dbContext.Project.Add(projectModal);
                    dbContext.SaveChanges();
                    retVal = projectDTO;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retVal;

        }
        /// <summary>
        /// method for deleting project
        /// </summary>
        /// <param name="projectDTO"></param>
        /// <returns>data of deleted project</returns>
        public ProjectDTO DeleteProject(ProjectDTO projectDTO)
        {
            ProjectDTO retVal = null;
            try
            {
                using (ManagementContext dbContext = new ManagementContext())
                {
                    ProjectModal projectModal = new ProjectModal();
                    projectModal.ProjId = projectDTO.projId;
                    var result = dbContext.Project.Find(projectModal.ProjId);
                    if (result != null)
                    {
                        dbContext.Project.Remove(result);
                    }
                    dbContext.SaveChanges();
                    retVal = projectDTO;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retVal;
        }

        /// <summary>
        /// method for fetching the detail for editing the project
        /// </summary>
        /// <param name="projectDTO"></param>
        /// <returns>project data with reference to id</returns>
        public ProjectDTO EditProject(ProjectDTO projectDTO)
        {
            ProjectDTO retVal = null;
            try
            {
                using (ManagementContext dbContext = new ManagementContext())
                {
                    ProjectModal projectModal = new ProjectModal();
                    projectModal.ProjId = projectDTO.projId;
                    var result = dbContext.Project.Find(projectModal.ProjId);
                    if (result != null)
                    {
                        projectDTO.projId = result.ProjId;
                        projectDTO.pname = result.Pname;
                        projectDTO.pdetail = result.Pdetail;
                        projectDTO.pdate = result.Pdate;
                    }

                    retVal = projectDTO;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retVal; ;
        }

        /// <summary>
        /// method for listing the project details
        /// </summary>
        /// <returns> list of project</returns>
        public ProjectListDTO ProjectList()
        {
            ProjectListDTO retVal = null;
            try
            {
                using (ManagementContext dbContext = new ManagementContext())
                {

                    var result = dbContext.Project.ToList();
                    List<ProjectDTO> projectDTOs = new List<ProjectDTO>();
                    ProjectListDTO projectListDTO = new ProjectListDTO();
                    var config = new MapperConfiguration(cfg => { cfg.CreateMap<ProjectModal, ProjectDTO>(); });
                    var mapper = config.CreateMapper();


                    foreach (var i in result)
                    {
                        var resultofi = mapper.Map<ProjectDTO>(i);
                        projectDTOs.Add(resultofi);
                    }
                    projectListDTO.ProjectList = projectDTOs;

                    retVal = projectListDTO;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retVal;
        }

        /// <summary>
        /// method for updating the project detail with new data
        /// </summary>
        /// <param name="projectDTO"></param>
        /// <returns>updated  project data</returns>
        public ProjectDTO UpdateProject(ProjectDTO projectDTO)
        {
            ProjectDTO retVal = null;
            try
            {
                using (ManagementContext dbContext = new ManagementContext())
                {
                    ProjectModal projectModal = new ProjectModal();
                    projectModal.ProjId = projectDTO.projId;
                    var result = dbContext.Project.Find(projectModal.ProjId);
                    if (result != null)
                    {
                        result.Pname = projectDTO.pname;
                        result.Pdetail = projectDTO.pdetail;
                        result.Pdate = projectDTO.pdate;
                    }
                    dbContext.SaveChanges();
                    retVal = projectDTO;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retVal; ;
        }
    }
}
