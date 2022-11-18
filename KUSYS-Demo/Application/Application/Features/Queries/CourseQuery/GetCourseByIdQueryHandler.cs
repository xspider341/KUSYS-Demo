
using Application.Contracts.Abstract;

namespace Application.Features.Queries.CourseQuery
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, CourseResponse>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;

        public GetCourseByIdQueryHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }
        public async Task<CourseResponse> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            CourseResponse response = new();
            var entity = _courseRepository.GetByIdAsync(request.Id).Result;
            if (entity is null || entity.Status == 2)
                throw new NotImplementedException();

            response = _mapper.Map<CourseResponse>(entity);
            return response;
        }
    }
}
