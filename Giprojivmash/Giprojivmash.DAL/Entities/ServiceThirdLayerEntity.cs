using System.ComponentModel.DataAnnotations.Schema;

namespace Giprojivmash.DAL.Entities
{
    [Table("ServiceThirdLayer")]
    public class ServiceThirdLayerEntity : BaseEntity
    {
        public string Description { get; set; }

        public int ServiceSecondLayerId { get; set; }
    }
}
