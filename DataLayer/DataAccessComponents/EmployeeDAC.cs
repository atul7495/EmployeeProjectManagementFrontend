using AutoMapper;
using DataLayer.Modals;
using SharedLayer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer
{
    public class EmployeeDAC : IEmployeeDAC
    {
        /// <summary>
        /// method for assigning project to employee
        /// </summary>
        /// <param name="id"></param>
        /// <param name="projectList"></param>
        /// <returns> array of project</returns>
        public ProjectDTO[] AssignProject(int id, ProjectDTO[] projectList)
        {
            ProjectDTO[] retVal = null;
            try
            {
                using (ManagementContext dbContext = new ManagementContext())
                {

                    foreach (var i in projectList)
                    {
                        ProjectAssign projectAssign = new ProjectAssign();
                        projectAssign.RefEmpId = id;
                        projectAssign.RefProjId = i.projId;
                        if (!dbContext.ProjectAssigns.Any(x => x.RefEmpId == projectAssign.RefEmpId)
                              && dbContext.ProjectAssigns.Any(x => x.RefProjId == projectAssign.RefProjId))
                            dbContext.ProjectAssigns.Add(projectAssign);
                    }
                    dbContext.SaveChanges();
                    retVal = projectList;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retVal;
        }

        /// <summary>
        /// method for fetching  employee with project allotment to reference of id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>list of empliyee</returns>
        public EmployeeListDTO AssignProjectList(int id)
        {
            EmployeeListDTO retVal = null;

            using (ManagementContext dbcontext = new ManagementContext())
            {
                EmployeeListDTO employeeList = new EmployeeListDTO();
                var result = dbcontext.ProjectAssigns.Where(x => x.RefEmpId == id).
                    Select(x => x.ProjectModal.Pname).ToList();
                employeeList.AssignProjectList = result;

                retVal = employeeList;
            }
            return retVal;
        }

        /// <summary>
        /// method for creating new employee
        /// </summary>
        /// <param name="employeeDTO"></param>
        /// <returns>single employee data</returns>
        public EmployeeDTO CreateEmployee(EmployeeDTO employeeDTO)
        {
            EmployeeDTO retVal = null;
            try
            {
                using (ManagementContext dbContext = new ManagementContext())
                {
                    EmployeeModal employeeModal = new EmployeeModal();
                    employeeModal.ename = employeeDTO.ename;
                    employeeModal.eage = employeeDTO.eage;
                    employeeModal.esal = employeeDTO.esal;

                    dbContext.Employee.Add(employeeModal);
                    dbContext.SaveChanges();
                    retVal = employeeDTO;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retVal;

        }

        /// <summary>
        /// method for deleting the employee from table
        /// </summary>
        /// <param name="employeeDTO"></param>
        /// <returns> data of deleted employee</returns>
        public EmployeeDTO DeleteEmployee(EmployeeDTO employeeDTO)
        {
            EmployeeDTO retVal = null;
            try
            {
                using (ManagementContext dbContext = new ManagementContext())
                {
                    EmployeeModal employeeModal = new EmployeeModal();
                    employeeModal.empId = employeeDTO.empId;
                    var result = dbContext.Employee.Find(employeeModal.empId);
                    if (result != null)
                    {
                        dbContext.Employee.Remove(result);
                    }
                    dbContext.SaveChanges();
                    retVal = employeeDTO;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retVal;
        }

        /// <summary>
        /// method for editing the employee
        /// </summary>
        /// <param name="employeeDTO"></param>
        /// <returns> employee data</returns>
        public EmployeeDTO EditEmployee(EmployeeDTO employeeDTO)
        {
            EmployeeDTO retVal = null;
            try
            {
                using (ManagementContext dbContext = new ManagementContext())
                {
                    EmployeeModal employeeModal = new EmployeeModal();
                    employeeModal.empId = employeeDTO.empId;
                    var result = dbContext.Employee.Find(employeeModal.empId);

                    if (result != null)
                    {
                        employeeDTO.empId = result.empId;
                        employeeDTO.ename = result.ename;
                        employeeDTO.eage = result.eage;
                        employeeDTO.esal = result.esal;
                    }

                    retVal = employeeDTO;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retVal;
        }

        /// <summary>
        /// method for listing all employee from table
        /// </summary>
        /// <returns>list of employee</returns>
        public EmployeeListDTO EmployeeListDTO()
        {
            EmployeeListDTO retVal = null;
            try
            {
                using (ManagementContext dbcontext = new ManagementContext())
                {
                    var result = dbcontext.Employee.ToList();

                    List<EmployeeDTO> employeeList = new List<EmployeeDTO>();
                    EmployeeListDTO employeeList1 = new EmployeeListDTO();
                    var config = new MapperConfiguration(cfg => { cfg.CreateMap<EmployeeModal, EmployeeDTO>(); });
                    var mapper = config.CreateMapper();
                    foreach (var i in result)
                    {
                        var resultofi = mapper.Map<EmployeeDTO>(i);
                        employeeList.Add(resultofi);
                    }

                    employeeList1.EmployeeList = employeeList;
                    retVal = employeeList1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retVal;
        }

        /// <summary>
        /// method for updating employee
        /// </summary>
        /// <param name="employeeDTO"></param>
        /// <returns>updated employee</returns>
        public EmployeeDTO UpdateEmployee(EmployeeDTO employeeDTO)
        {
            EmployeeDTO retVal = null;
            try
            {
                using (ManagementContext dbContext = new ManagementContext())
                {
                    var result = dbContext.Employee.Where(x => x.empId == employeeDTO.empId).SingleOrDefault();
                    EmployeeModal employeeModal = new EmployeeModal();

                    result.ename = employeeDTO.ename;
                    result.eage = employeeDTO.eage;
                    result.esal = employeeDTO.esal;
                    dbContext.SaveChanges();
                    retVal = employeeDTO;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retVal;
        }
    }
}
