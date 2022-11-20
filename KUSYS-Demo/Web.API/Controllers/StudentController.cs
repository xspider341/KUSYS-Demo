

namespace Web.API.Controllers
{

    // [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "AddStudent")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<StudentResponse>> AddStudent([FromBody] CreateStudentCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }
        [HttpDelete(Name = "DeleteStudent")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<StudentResponse>> DeleteStudent([FromBody] DeleteStudentCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }
        [HttpPut(Name = "UpdateStudent")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<StudentResponse>> UpdateStudent([FromBody] UpdateStudentCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }

        [HttpGet(Name = "GetAllStudents")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<StudentResponse>>> GetAll()
        {
            GetStudentListQuery command = new GetStudentListQuery();
            var result = await _mediator.Send(command);
            return result;
        }
        [HttpGet(Name = "GetStudentById")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<StudentResponse>> GetbyId(long ID)
        {
            GetStudentByIdQuery command = new GetStudentByIdQuery(ID);
            var result = await _mediator.Send(command);
            return result;
        }

    }
}
