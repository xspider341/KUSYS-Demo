
namespace Application.Features.Command.Course
{
    public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, CourseResponse>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ILogger<CreateCourseCommandHandler> _logger;
        private readonly IMapper _mapper;

        public CreateCourseCommandHandler(ICourseRepository courseRepository, ILogger<CreateCourseCommandHandler> logger, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _logger = logger;
            _mapper = mapper;
        }


        public async Task<CourseResponse> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            CourseResponse response = new();
            var entity = _mapper.Map<Domain.Entities.Course>(request);
            await _courseRepository.AddAsync(entity);
            response = _mapper.Map<CourseResponse>(entity);
            return response;
        }
    }
}
