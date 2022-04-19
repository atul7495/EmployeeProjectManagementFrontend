using BussinessLayer;
using SharedLayer;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectManagementApi.Controllers
{
    public class ProjectAssignController : ApiController
    {
        // GET api/<controller>


        /// <summary>
        /// api for assign project to employee
        /// </summary>
        /// <param name="id"></param>
        /// <returns> asiign project list to employee </returns>
        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            EmployeeBDC employeeBDC = new EmployeeBDC();
            OperationalResult<EmployeeListDTO> operationalResult = employeeBDC.GetAssignProject(id);
            if (operationalResult.isValid())
            {
                return Request.CreateResponse(HttpStatusCode.OK, operationalResult.Data.AssignProjectList);
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Not Found");

        }

        /// <summary>
        /// patch api for geting the employee detail assigned to given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> list of employee</returns>

        // POST api/<controller>
        public HttpResponseMessage Patch(int id)
        {
            ProjectAssignBDC projectAssignBDC = new ProjectAssignBDC();
            OperationalResult<EmployeeListDTO> operationalResult = projectAssignBDC.GetAssignEmp(id);
            if (operationalResult.isValid())
            {
                return Request.CreateResponse(HttpStatusCode.OK, operationalResult.Data.EmployeeList);
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Not Found");

        }

        // PUT api/<controller>/5
        /// <summary>
        /// post api for removing assigned employee from project
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employeeDTO"></param>
        /// <returns> data of removed employee</returns>
        public HttpResponseMessage Post(int id, EmployeeDTO[] employeeDTO)
        {
            ProjectAssignBDC projectAssignBDC = new ProjectAssignBDC();
            OperationalResult<EmployeeDTO[]> operationalResult = projectAssignBDC.RemoveEmployee(id, employeeDTO);
            if (operationalResult.isValid())
            {
                return Request.CreateResponse(HttpStatusCode.OK, operationalResult.Data);
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Not Found");

        }

      
    }
}