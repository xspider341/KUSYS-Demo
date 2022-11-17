
namespace Application.Features.Queries.CourseQuery
{
    public class GetCourseListQueryHandler : IRequestHandler<GetCourseListQuery, List<CourseResponse>>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public GetCourseListQueryHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<List<CourseResponse>> Handle(GetCourseListQuery request, CancellationToken cancellationToken)
        {
            var response = new List<CourseResponse>();
            var entity = _courseRepository.GetAllAsync(e => e.Status==1).Result;

            response = _mapper.Map<List<CourseResponse>>(entity);
            return response;
        }
    }
}
