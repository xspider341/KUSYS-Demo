
namespace Application.Features.Command.Course
{
    public class DeleteCourseCommand :  IRequest<CourseResponse>
    {
        public DeleteCourseCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
