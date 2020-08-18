using System.ComponentModel.DataAnnotations.Schema;

namespace Giprojivmash.DAL.Entities
{
    [Table("contact")]
    public class ContactEntity : BaseEntity
    {
        public string Position { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Patronymic { get; set; }

        public string Photo { get; set; }

        public string Description { get; set; }
    }
}
