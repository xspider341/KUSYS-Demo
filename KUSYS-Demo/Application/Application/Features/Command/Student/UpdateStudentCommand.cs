
namespace Application.Features.Command.Student
{
    public class UpdateStudentCommand : IRequest<StudentResponse>
    {
        public UpdateStudentCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
