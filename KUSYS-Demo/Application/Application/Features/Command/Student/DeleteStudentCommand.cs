
namespace Application.Features.Command.Student
{
    public class DeleteStudentCommand : StudentRequest, IRequest<StudentResponse>
    {
        public DeleteStudentCommand(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
