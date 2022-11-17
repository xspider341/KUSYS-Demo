
namespace Application.Features.Command.Course
{
    public class UpdateCourseCommand : IRequest<CourseResponse>
    {
        public UpdateCourseCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
