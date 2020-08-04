using System.ComponentModel.DataAnnotations.Schema;

namespace Giprojivmash.DAL.Entities
{
    [Table("servicefirstlayer")]
    public class ServiceFirstLayerEntity : BaseEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string DescriptionShort { get; set; }

        public string PhotoTitle { get; set; }
    }
}
