
namespace Application.Features.Queries.StudentQuery
{
    public class GetStudentByIdQuery : IRequest<StudentResponse>
    {
        public GetStudentByIdQuery(long id)
        {
            Id = id;
        }

        public long Id { get; set; }
    }
}
