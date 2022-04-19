using BussinessLayer;
using DataLayer;
using SharedLayer;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProjectManagementApi.Controllers
{
    public class ProjectController : ApiController
    {
        // GET api/<controller>

        /// <summary>
        /// get post for fetching data using id
        /// </summary>
        /// <param name="id"></param>
        /// <returns> project list</returns>
        public HttpResponseMessage Get(int id)
        {
            ProjectDTO projectDTO = new ProjectDTO();
            projectDTO.projId = id;
            ProjectBDC projectBDC = new ProjectBDC();
            OperationalResult<ProjectDTO> operationalResult = projectBDC.EditProject(projectDTO);
            if (operationalResult.isValid())
            {
                return Request.CreateResponse(HttpStatusCode.OK, operationalResult.Data);
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Not Found");
        }

        /// <summary>
        /// get api method for listing all project
        /// </summary>
        /// <returns>data in form of array</returns>
        // GET api/<controller>/5
        [HttpGet]
        [Route("api/ProjectList")]
        public HttpResponseMessage AllProject()
        {
            ProjectBDC projectBDC = new ProjectBDC();
            OperationalResult<ProjectListDTO> operationalResult = projectBDC.ProjectList();
            if (operationalResult.isValid())
            {
                return Request.CreateResponse(HttpStatusCode.OK, operationalResult.Data.ProjectList);
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Not Found");
        }

        // POST api/<controller>
        /// <summary>
        /// post api for creating new project
        /// </summary>
        /// <param name="projectModal"></param>
        /// <returns>data of new project</returns>
        public HttpResponseMessage Post(ProjectModal projectModal)
        {
            ProjectDTO projectDTO = new ProjectDTO();
            projectDTO.pname = projectModal.Pname;
            projectDTO.pdetail = projectModal.Pdetail;
            projectDTO.pdate = projectModal.Pdate;


            ProjectBDC projectBDC = new ProjectBDC();
            OperationalResult<ProjectDTO> operationalResult = projectBDC.CreateProject(projectDTO);
            if (operationalResult.isValid())
            {
                return Request.CreateResponse(HttpStatusCode.OK, operationalResult.Data);
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Not Found");
        }

        /// <summary>
        /// put api for updating the project
        /// </summary>
        /// <param name="id"></param>
        /// <param name="projectModal"></param>
        /// <returns></returns>
        // PUT api/<controller>/5
        public HttpResponseMessage Put(int id, ProjectModal projectModal)
        {
            ProjectDTO projectDTO = new ProjectDTO();
            projectDTO.projId = id;
            projectDTO.pname = projectModal.Pname;
            projectDTO.pdetail = projectModal.Pdetail;
            projectDTO.pdate = projectModal.Pdate;
            ProjectBDC projectBDC = new ProjectBDC();
            OperationalResult<ProjectDTO> operationalResult = projectBDC.UpdateProject(projectDTO);
            if (operationalResult.isValid())
            {
                return Request.CreateResponse(HttpStatusCode.OK, operationalResult.Data);
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Not Found");

        }
        /// <summary>
        /// delete api for removing project
        /// </summary>
        /// <param name="id"></param>
        /// <returns>deleted project</returns>
        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int id)
        {
            ProjectDTO projectDTO = new ProjectDTO();
            projectDTO.projId = id;
            ProjectBDC projectBDC = new ProjectBDC();
            OperationalResult<ProjectDTO> operationalResult = projectBDC.DeleteProject(projectDTO);
            if (operationalResult.isValid())
            {
                return Request.CreateResponse(HttpStatusCode.OK, operationalResult.Data);
            }
            return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Not Found");
        }
    }
}