
namespace Application.Features.Command.Course
{
    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, CourseResponse>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly ILogger<DeleteCourseCommandHandler> _logger;
        private readonly IMapper _mapper;

        public DeleteCourseCommandHandler(ICourseRepository courseRepository, ILogger<DeleteCourseCommandHandler> logger, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<CourseResponse> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            var response = new CourseResponse();
            var entity = _courseRepository.GetByIdAsync(request.Id).Result;
            if (entity == null)
            {
                throw new NotImplementedException();

            }
            entity.Status = 2;
            await _courseRepository.DeleteAsync(entity);
            response = _mapper.Map<CourseResponse>(entity);
            return response;
        }

        
    }
}
