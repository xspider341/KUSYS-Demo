
namespace Domain.Response
{
    public class StudentResponse
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public long CourseId { get; set; }
        public CourseResponse Course { get; set; } = new CourseResponse();
    }
}
