using BussinessLayer;
using DataLayer;
using SharedLayer;
using System.Net.Http;
using System.Web.Http;

namespace ProjectManagementApi.Controllers
{
    public class EmployeeController : ApiController
    {
        /// <summary>
        /// api for creating new employee
        /// </summary>
        /// <param name="employeeModal"></param>
        /// <returns>amployeeDTO object</returns>

        [HttpPost]
        // GET api/<controller>
        [Route("api/Employee")]
        public HttpResponseMessage createEmp(EmployeeModal employeeModal)
        {
            EmployeeDTO employeeDTO = new EmployeeDTO();
            employeeDTO.ename = employeeModal.ename;
            employeeDTO.eage = employeeModal.eage;
            employeeDTO.esal = employeeModal.esal;

            EmployeeBDC employeeBDC = new EmployeeBDC();
            OperationalResult<EmployeeDTO> operationalResult = employeeBDC.CreateEmployee(employeeDTO);
            if (operationalResult.isValid())
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, operationalResult.Data);
            }
            return Request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, "Not Found");
        }

        /// <summary>
        /// api for getting employee details with the specific id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>employee detail</returns>
        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            EmployeeDTO employeeDTO = new EmployeeDTO();
            employeeDTO.empId = id;
            EmployeeBDC employeeBDC = new EmployeeBDC();
            OperationalResult<EmployeeDTO> operationalResult = employeeBDC.EditEmployee(employeeDTO);
            if (operationalResult.isValid())
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, operationalResult.Data);
            }
            return Request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, "Not Found");
        }

        /// <summary>
        /// api for listing all the employee
        /// </summary>
        /// <returns> list of employee</returns>

        [HttpGet]
        [Route("api/EmployeeList")]
        public HttpResponseMessage AllEmployee()
        {
            EmployeeBDC employeeBDC = new EmployeeBDC();
            OperationalResult<EmployeeListDTO> operationalResult = employeeBDC.EmployeeList();

            if (operationalResult.isValid())
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, operationalResult.Data.EmployeeList);
            }
            return Request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, "Not Found");
        }
        // POST api/<controller>
        /// <summary>
        /// api for saving the assignment into database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="projectDTOs"></param>
        /// <returns></returns>

        [HttpPost]
        public HttpResponseMessage Post(int id, ProjectDTO[] projectDTOs)
        {
            EmployeeBDC employeeBDC = new EmployeeBDC();
            OperationalResult<ProjectDTO[]> operationalResult = employeeBDC.AssignProject(id, projectDTOs);
            if (operationalResult.isValid())
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, operationalResult.Data);
            }

            return Request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, "Not Found");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="employeeModal"></param>
        /// <returns></returns>
        // PUT api/<controller>/5

        public HttpResponseMessage Put(int id, EmployeeModal employeeModal)
        {
            EmployeeDTO employeeDTO = new EmployeeDTO();
            employeeDTO.empId = id;
            employeeDTO.ename = employeeModal.ename;
            employeeDTO.eage = employeeModal.eage;
            employeeDTO.esal = employeeModal.esal;
            EmployeeBDC employeeBDC = new EmployeeBDC();
            OperationalResult<EmployeeDTO> operationalResult = employeeBDC.UpdateEmployee(employeeDTO);
            if (operationalResult.isValid())
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, operationalResult.Data);
            }
            return Request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, "Not Found");
        }

        /// <summary>
        /// api for deleting the employee with the given id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            EmployeeDTO employeeDTO = new EmployeeDTO();
            employeeDTO.empId = id;
            EmployeeBDC employeeBDC = new EmployeeBDC();
            OperationalResult<EmployeeDTO> operationalResult = employeeBDC.DeleteEmployee(employeeDTO);
            if (operationalResult.isValid())
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, operationalResult.Data);
            }
            return Request.CreateErrorResponse(System.Net.HttpStatusCode.InternalServerError, "Not Found");
        }


    }
}