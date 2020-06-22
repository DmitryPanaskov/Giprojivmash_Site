using System.ComponentModel.DataAnnotations.Schema;

namespace Giprojivmash.DAL.Entities
{
    [Table("ServiceFirstLayer")]
    public class ServiceFirstLayerEntity : BaseEntity
    {
        public string Description { get; set; }
    }
}
