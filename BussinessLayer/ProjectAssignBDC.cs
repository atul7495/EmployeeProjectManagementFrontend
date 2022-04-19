using DataLayer.DataAccessComponents;
using SharedLayer;
using SharedLayer.Business;
using System;

namespace BussinessLayer
{
    public class ProjectAssignBDC : IProjectAssignBDC
    {
        /// <summary>
        /// method for getting assigne list of employee in business component
        /// </summary>
        /// <param name="id"></param>
        /// <returns>success,failure and exception result</returns>
        public OperationalResult<EmployeeListDTO> GetAssignEmp(int id)
        {
            OperationalResult<EmployeeListDTO> retval = null;
            try
            {
                ProjectAssignDAC projectAssignDAC = new ProjectAssignDAC();
                var result = projectAssignDAC.GetAssignEmp(id);
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
        /// method for removing employee in business component
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employeeDTO"></param>
        /// <returns>success,failure and exception result</returns>
        public OperationalResult<EmployeeDTO[]> RemoveEmployee(int id, EmployeeDTO[] employeeDTO)
        {
            OperationalResult<EmployeeDTO[]> retval = null;
            try
            {
                ProjectAssignDAC projectAssignDAC = new ProjectAssignDAC();
                var result = projectAssignDAC.RemoveEmployee(id, employeeDTO);
                if (result != null)
                {
                    retval = OperationalResult<EmployeeDTO[]>.successResult(result);

                }
                else
                {
                    retval = OperationalResult<EmployeeDTO[]>.failureResult("failed");
                }
            }
            catch (Exception ex)
            {
                retval = OperationalResult<EmployeeDTO[]>.errorResult(ex.Message, ex.StackTrace);
            }
            return retval;
        }
    }
}
