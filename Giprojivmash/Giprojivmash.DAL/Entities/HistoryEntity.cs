using System.ComponentModel.DataAnnotations.Schema;

namespace Giprojivmash.DAL.Entities
{
    [Table("history")]
    public class HistoryEntity : BaseEntity
    {
        public string Description { get; set; }
    }
}
