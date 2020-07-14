using System.ComponentModel.DataAnnotations.Schema;

namespace Giprojivmash.DAL.Entities
{
    [Table("portfoliophoto")]
    public class PortfolioPhotoEntity : BaseEntity
    {
        public int PortfolioId { get; set; }

        public string PhotoName { get; set; }
    }
}
