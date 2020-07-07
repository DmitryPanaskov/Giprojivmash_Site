using System.ComponentModel.DataAnnotations.Schema;

namespace Giprojivmash.DAL.Entities
{
    [Table("ServiceFirstLayer")]
    public class ServiceFirstLayerEntity : BaseEntity
    {
        public string ServiceTitle { get; set; }

        public string Description { get; set; }

        public string PhotoTitle { get; set; }

        public string PhotoAlt { get; set; }
    }
}
