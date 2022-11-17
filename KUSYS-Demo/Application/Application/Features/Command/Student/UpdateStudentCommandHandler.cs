
namespace Application.Features.Command.Student
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommand, StudentResponse>
    {
        private readonly IStudentRepository _StudentRepository;
        private readonly ILogger<UpdateStudentCommandHandler> _logger;
        private readonly IMapper _mapper;

        public UpdateStudentCommandHandler(IStudentRepository StudentRepository, ILogger<UpdateStudentCommandHandler> logger, IMapper mapper)
        {
            _StudentRepository = StudentRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<StudentResponse> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var response = new StudentResponse();
            var entity = _StudentRepository.GetByIdAsync(request.Id).Result;
            if (entity is null)
            {
                throw new NotImplementedException();
            }

            await _StudentRepository.UpdateAsync(entity);
            response = _mapper.Map<StudentResponse>(entity);
            return response;
        }
    }
}
