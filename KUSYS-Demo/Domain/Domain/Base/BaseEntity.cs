namespace Domain.Base
{
    public class BaseEntity
    {
        public long Id { get; set; }
        public int Status { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
