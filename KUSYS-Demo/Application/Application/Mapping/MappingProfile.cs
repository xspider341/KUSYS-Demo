using Application.Features.Command.Course;
using Application.Features.Command.Student;

namespace Application.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Course, CreateCourseCommand>()
                .ReverseMap()
                   .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 1))
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => DateTime.Now.Date));

            CreateMap<Course, CourseResponse>().ReverseMap();


            CreateMap<Student, CreateStudentCommand>()
                .ReverseMap()
                  .ForMember(dest => dest.Status, opt => opt.MapFrom(src => 1))
                .ForMember(dest => dest.CreateDate, opt => opt.MapFrom(src => DateTime.Now.Date));

            CreateMap<Student, StudentResponse>().ReverseMap();
        }
    }
}
