
namespace Application.Features.Queries.StudentQuery
{
    public class GetStudentListQueryHandler : IRequestHandler<GetStudentListQuery, List<StudentResponse>>
    {
        private readonly IStudentRepository _StudentRepository;
        private readonly IMapper _mapper;

        public GetStudentListQueryHandler(IStudentRepository StudentRepository, IMapper mapper)
        {
            _StudentRepository = StudentRepository;
            _mapper = mapper;
        }

        public async Task<List<StudentResponse>> Handle(GetStudentListQuery request, CancellationToken cancellationToken)
        {
            List<StudentResponse> response = new ();
            var entity = _StudentRepository.GetAllAsync(e => e.Status == 1).Result;
            response = _mapper.Map<List<StudentResponse>>(entity);
            return response;
        }
    }
}
