using System.ComponentModel.DataAnnotations.Schema;

namespace Giprojivmash.DAL.Entities
{
    [Table("portfolio")]
    public class PortfolioEntity : BaseEntity
    {
        public string Description { get; set; }
    }
}
