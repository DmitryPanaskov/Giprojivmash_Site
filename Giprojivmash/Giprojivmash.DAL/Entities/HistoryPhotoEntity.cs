using System.ComponentModel.DataAnnotations.Schema;

namespace Giprojivmash.DAL.Entities
{
    [Table("HistoryPhoto")]
    public class HistoryPhotoEntity : BaseEntity
    {
        public int HistoryId { get; set; }

        public string PhotoName { get; set; }
    }
}
