using System.ComponentModel.DataAnnotations.Schema;
using Giprojivmash.DataModels.Enums;

namespace Giprojivmash.DAL.Entities
{
    [Table("contact")]
    public class ContactEntity : BaseEntity
    {
        public string Position { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Gender Gender { get; set; }

        public string Patronymic { get; set; }

        public string Photo { get; set; }

        public string Description { get; set; }

        public int IndexNumber { get; set; }

        public PositionType PositionType { get; set; }
    }
}
