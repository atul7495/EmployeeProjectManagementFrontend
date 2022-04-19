using AutoMapper;
using DataLayer.Modals;
using SharedLayer;
using SharedLayer.DAC;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLayer.DataAccessComponents
{
    public class ProjectAssignDAC : IProjectAssignDAC
    {
        public EmployeeListDTO GetAssignEmp(int id)
        {
            EmployeeListDTO retVal = null;
            try
            {
                using (ManagementContext dbcontext = new ManagementContext())
                {
                    List<EmployeeDTO> employee = new List<EmployeeDTO>();

                    var result = dbcontext.ProjectAssigns.Where(x => x.RefProjId == id).Select(x => x.EmployeeModal).ToList();

                    EmployeeListDTO employeeList = new EmployeeListDTO();
                    var config = new MapperConfiguration(cfg => { cfg.CreateMap<EmployeeModal, EmployeeDTO>(); });
                    var mapper = config.CreateMapper();
                    foreach (var i in result)
                    {
                        var resultofi = mapper.Map<EmployeeDTO>(i);
                        employee.Add(resultofi);
                    }

                    employeeList.EmployeeList = employee;
                    retVal = employeeList;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retVal;
        }

        public EmployeeDTO[] RemoveEmployee(int id, EmployeeDTO[] employeeDTOs)
        {
            EmployeeDTO[] retval = null;
            try
            {
                using (ManagementContext dbcontext = new ManagementContext())
                {


                    foreach (var i in employeeDTOs)
                    {
                        ProjectAssign projectAssign = new ProjectAssign();
                        projectAssign.RefProjId = id;
                        projectAssign.RefEmpId = i.empId;
                        var result = dbcontext.ProjectAssigns.Where(x => x.RefProjId == projectAssign.RefProjId && x.RefEmpId == projectAssign.RefEmpId).Select(x => x.ProjAssignId).First();
                        var result2 = dbcontext.ProjectAssigns.Find(result);
                        dbcontext.ProjectAssigns.Remove(result2);
                    }
                    dbcontext.SaveChanges();

                    retval = employeeDTOs;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return retval;
        }
    }
}