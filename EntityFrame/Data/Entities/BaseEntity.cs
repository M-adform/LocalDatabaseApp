using System.ComponentModel.DataAnnotations;

namespace EntityFrame.Data.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public string? CreatedBy { get; set; }
        public bool Deleted { get; set; }
        public DateTime? Modified { get; set; }
        public string? ModifiedBy { get; set; }

        public BaseEntity()
        {
            Deleted = false;
            Id = Guid.NewGuid();
            Created = DateTime.Now;
        }
    }
}
