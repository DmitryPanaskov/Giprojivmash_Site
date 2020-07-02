using System.ComponentModel.DataAnnotations.Schema;

namespace Giprojivmash.DAL.Entities
{
    [Table("History")]
    public class HistoryEntity : BaseEntity
    {
        public string Description { get; set; }
    }
}
