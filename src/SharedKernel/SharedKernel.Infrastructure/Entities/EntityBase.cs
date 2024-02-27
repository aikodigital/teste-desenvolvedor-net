using System.ComponentModel.DataAnnotations.Schema;

namespace SharedKernel.Infrastructure.Entities
{
    public class EntityBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; private set; }


    }
}
