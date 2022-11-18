
namespace Application.Features.Command.Student
{
    public class DeleteStudentCommandHandler : IRequestHandler<DeleteStudentCommand, StudentResponse>
    {
        private readonly IStudentRepository _StudentRepository;
        private readonly ILogger<DeleteStudentCommandHandler> _logger;
        private readonly IMapper _mapper;

        public DeleteStudentCommandHandler(IStudentRepository StudentRepository, ILogger<DeleteStudentCommandHandler> logger, IMapper mapper)
        {
            _StudentRepository = StudentRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<StudentResponse> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            StudentResponse response = new ();
            var entity = _StudentRepository.GetByIdAsync(request.Id).Result;
            if (entity is null || entity.Status == 2)
                throw new NotImplementedException();

            entity.Status = 2;
            await _StudentRepository.DeleteAsync(entity);
            response = _mapper.Map<StudentResponse>(entity);
            return response;
        }


    }
}
