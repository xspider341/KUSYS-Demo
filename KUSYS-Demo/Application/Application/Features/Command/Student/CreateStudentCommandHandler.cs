
namespace Application.Features.Command.Student
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, StudentResponse>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly ILogger<CreateStudentCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateStudentCommandHandler(IStudentRepository studentRepository, ILogger<CreateStudentCommandHandler> logger, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<StudentResponse> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
        {
            StudentResponse response = new();
            var entity = _mapper.Map<Domain.Entities.Student>(request);
            await _studentRepository.AddAsync(entity);
            response = _mapper.Map<StudentResponse>(entity);
            return response;
        }
    }

}
