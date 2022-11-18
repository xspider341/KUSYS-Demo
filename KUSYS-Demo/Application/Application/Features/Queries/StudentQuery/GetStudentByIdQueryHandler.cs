
namespace Application.Features.Queries.StudentQuery
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentResponse>
    {
        private readonly IStudentRepository _StudentRepository;
        private readonly IMapper _mapper;

        public GetStudentByIdQueryHandler(IStudentRepository StudentRepository, IMapper mapper)
        {
            _StudentRepository = StudentRepository;
            _mapper = mapper;
        }
        public async Task<StudentResponse> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            StudentResponse response = new ();
            var entity = _StudentRepository.GetByIdAsync(request.Id).Result;
            if (entity is null || entity.Status is 2)
                throw new NotImplementedException();

            response = _mapper.Map<StudentResponse>(entity);
            return response;
        }
    }
}
