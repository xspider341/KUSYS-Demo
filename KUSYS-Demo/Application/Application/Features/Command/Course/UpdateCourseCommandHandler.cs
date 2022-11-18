
namespace Application.Features.Command.Course
{
    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, CourseResponse>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ILogger<UpdateCourseCommandHandler> _logger;
        private readonly IMapper _mapper;

        public UpdateCourseCommandHandler(ICourseRepository courseRepository, ILogger<UpdateCourseCommandHandler> logger, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<CourseResponse> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            CourseResponse response = new ();
            var entity = _courseRepository.GetByIdAsync(request.Id).Result;
            if (entity is null || entity.Status == 2)
                throw new NotImplementedException();

            await _courseRepository.UpdateAsync(entity);
            response = _mapper.Map<CourseResponse>(entity);
            return response;
        }
    }
}
