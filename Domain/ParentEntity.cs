using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.ApplicationUserAggregate;

namespace Domain
{
    public abstract class ParentEntity : ParentEntityWithoutUser
    {
        [ForeignKey("Created")]
        public string? CreatedBy { get; protected set; }
        [ForeignKey("Updated")]
        public string? UpdatedBy { get; protected set; }

        public virtual ApplicationUser Created { get; private set; }
        public virtual ApplicationUser Updated { get; private set; }

    }


    public abstract class ParentEntityWithoutUser
    {
        [Key]
        public string Id { get; protected set; }
        public bool IsDeleted { get; protected set; }

        public DateTime CreationTime { get; protected set; }
        public DateTime? UpdateTime { get; protected set; }
    }

}
