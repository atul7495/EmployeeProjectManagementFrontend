using DataLayer;
using SharedLayer;
using SharedLayer.Business;
using System;

namespace BussinessLayer
{
    /// <summary>
    /// business domain component for the employee
    /// </summary>
    public class EmployeeBDC : IEmployeeBDC
    {
        /// <summary>
        /// method for assigned project in busniess component
        /// </summary>
        /// <param name="id"></param>
        /// <param name="projectDTO"></param>
        /// <returns>success result with project data</returns>
        public OperationalResult<ProjectDTO[]> AssignProject(int id, ProjectDTO[] projectDTO)
        {
            OperationalResult<ProjectDTO[]> retval = null;
            try
            {
                EmployeeDAC employeeDAC = new EmployeeDAC();
                employeeDAC.AssignProject(id, projectDTO);
                if (employeeDAC != null)
                {
                    retval = OperationalResult<ProjectDTO[]>.successResult(projectDTO);

                }
                else
                {
                    retval = OperationalResult<ProjectDTO[]>.failureResult("failed");
                }
            }
            catch (Exception ex)
            {
                retval = OperationalResult<ProjectDTO[]>.errorResult(ex.Message, ex.StackTrace);
            }
            return retval;
        }

        /// <summary>
        /// method for creating employee in business component
        /// </summary>
        /// <param name="employeeDTO"></param>
        /// <returns> success result with employee data</returns>
        public OperationalResult<EmployeeDTO> CreateEmployee(EmployeeDTO employeeDTO)
        {
            OperationalResult<EmployeeDTO> retval = null;
            try
            {
                EmployeeDAC employeeDAC = new EmployeeDAC();
                employeeDAC.CreateEmployee(employeeDTO);
                if (employeeDAC != null)
                {
                    retval = OperationalResult<EmployeeDTO>.successResult(employeeDTO);

                }
                else
                {
                    retval = OperationalResult<EmployeeDTO>.failureResult("failed");
                }
            }
            catch (Exception ex)
            {
                retval = OperationalResult<EmployeeDTO>.errorResult(ex.Message, ex.StackTrace);
            }
            return retval;
        }

        /// <summary>
        /// method for delete employee in business domain component
        /// </summary>
        /// <param name="employeeDTO"></param>
        /// <returns>success , failure and exception result</returns>
        public OperationalResult<EmployeeDTO> DeleteEmployee(EmployeeDTO employeeDTO)
        {
            OperationalResult<EmployeeDTO> retval = null;
            try
            {
                EmployeeDAC employeeDAC = new EmployeeDAC();
                employeeDAC.DeleteEmployee(employeeDTO);
                if (employeeDAC != null)
                {
                    retval = OperationalResult<EmployeeDTO>.successResult(employeeDTO);

                }
                else
                {
                    retval = OperationalResult<EmployeeDTO>.failureResult("failed");
                }
            }
            catch (Exception ex)
            {
                retval = OperationalResult<EmployeeDTO>.errorResult(ex.Message, ex.StackTrace);
            }
            return retval;
        }

        /// <summary>
        /// method for edit employee in business component
        /// </summary>
        /// <param name="employeeDTO"></param>
        /// <returns>sucess,failure and exception result</returns>
        public OperationalResult<EmployeeDTO> EditEmployee(EmployeeDTO employeeDTO)
        {
            OperationalResult<EmployeeDTO> retval = null;
            try
            {
                EmployeeDAC employeeDAC = new EmployeeDAC();
                employeeDAC.EditEmployee(employeeDTO);
                if (employeeDAC != null)
                {
                    retval = OperationalResult<EmployeeDTO>.successResult(employeeDTO);

                }
                else
                {
                    retval = OperationalResult<EmployeeDTO>.failureResult("failed");
                }
            }
            catch (Exception ex)
            {
                retval = OperationalResult<EmployeeDTO>.errorResult(ex.Message, ex.StackTrace);
            }
            return retval;
        }
        /// <summary>
        /// method for employee list in business component
        /// </summary>
        /// <returns>success,failure and exception result</returns>
        public OperationalResult<EmployeeListDTO> EmployeeList()
        {
            OperationalResult<EmployeeListDTO> retval = null;
            try
            {
                EmployeeDAC employeeDAC = new EmployeeDAC();
                var result = employeeDAC.EmployeeListDTO();
                if (result != null)
                {
                    retval = OperationalResult<EmployeeListDTO>.successResult(result);

                }
                else
                {
                    retval = OperationalResult<EmployeeListDTO>.failureResult("failed");
                }
            }
            catch (Exception ex)
            {
                retval = OperationalResult<EmployeeListDTO>.errorResult(ex.Message, ex.StackTrace);
            }
            return retval;
        }

        /// <summary>
        /// method for list of assigned project in business component
        /// </summary>
        /// <param name="id"></param>
        /// <returns> success , failure and error result</returns>
        public OperationalResult<EmployeeListDTO> GetAssignProject(int id)
        {
            OperationalResult<EmployeeListDTO> retval = null;
            try
            {
                EmployeeDAC employeeDAC = new EmployeeDAC();
                var result = employeeDAC.AssignProjectList(id);
                if (result != null)
                {
                    retval = OperationalResult<EmployeeListDTO>.successResult(result);

                }
                else
                {
                    retval = OperationalResult<EmployeeListDTO>.failureResult("failed");
                }
            }
            catch (Exception ex)
            {
                retval = OperationalResult<EmployeeListDTO>.errorResult(ex.Message, ex.StackTrace);
            }
            return retval;
        }
        /// <summary>
        /// method for updating employee in business component
        /// </summary>
        /// <param name="employeeDTO"></param>
        /// <returns>success,failure and exception result</returns>
        public OperationalResult<EmployeeDTO> UpdateEmployee(EmployeeDTO employeeDTO)
        {
            OperationalResult<EmployeeDTO> retval = null;
            try
            {
                EmployeeDAC employeeDAC = new EmployeeDAC();
                employeeDAC.UpdateEmployee(employeeDTO);
                if (employeeDAC != null)
                {
                    retval = OperationalResult<EmployeeDTO>.successResult(employeeDTO);

                }
                else
                {
                    retval = OperationalResult<EmployeeDTO>.failureResult("failed");
                }
            }
            catch (Exception ex)
            {
                retval = OperationalResult<EmployeeDTO>.errorResult(ex.Message, ex.StackTrace);
            }
            return retval;
        }
    }
}
