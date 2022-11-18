
using Application.Features.Command.Course;

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
            StudentResponse response = new();
            var entity = _StudentRepository.GetByIdAsync(request.Id).Result;
            if (entity is null || entity.Status == 2)
                throw new NotImplementedException();

            _mapper.Map(request, entity, typeof(UpdateStudentCommand), typeof(Domain.Entities.Student));
            await _StudentRepository.UpdateAsync(entity);
            response = _mapper.Map<StudentResponse>(entity);
            return response;
        }
    }
}
