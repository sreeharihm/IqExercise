namespace Domain.Common
{
    public class BaseEntity
    {
        public Guid Guid { get; set; }
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
