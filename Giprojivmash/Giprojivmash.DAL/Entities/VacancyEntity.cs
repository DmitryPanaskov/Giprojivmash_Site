using System.ComponentModel.DataAnnotations.Schema;

namespace Giprojivmash.DAL.Entities
{
    [Table("vacancy")]
    public class VacancyEntity : BaseEntity
    {
        public string Position { get; set; }

        public string Description { get; set; }

        public string Contact { get; set; }
    }
}
