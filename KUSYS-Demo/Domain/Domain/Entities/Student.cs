using Domain.Base;

namespace Domain.Entities
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public long CourseId { get; set; }
        public virtual Course Course { get; set; }
    }
}
