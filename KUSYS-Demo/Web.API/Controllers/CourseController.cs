

namespace Web.API.Controllers
{

    // [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "AddCourse")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<CourseResponse>> AddCourse([FromBody] CreateCourseCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }
        [HttpDelete(Name = "DeleteCourse")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<CourseResponse>> DeleteCourse(long ID)
        {
            DeleteCourseCommand command = new DeleteCourseCommand(ID);
            var result = await _mediator.Send(command);
            return result;
        }
        [HttpPut(Name = "UpdateCourse")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<CourseResponse>> UpdateCourse([FromBody] UpdateCourseCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }

        [HttpGet(Name = "GetAllCourses")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<List<CourseResponse>>> GetAll()
        {
            GetCourseListQuery command = new GetCourseListQuery();
            var result = await _mediator.Send(command);
            return result;
        }
        [HttpGet(Name = "GetCourseById")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<ActionResult<CourseResponse>> GetbyId(long ID)
        {
            GetCourseByIdQuery command = new GetCourseByIdQuery(ID);
            var result = await _mediator.Send(command);
            return result;
        }

    }
}
