using System.ComponentModel.DataAnnotations.Schema;

namespace Giprojivmash.DAL.Entities
{
    [Table("ContactPhone")]
    public class ContactPhoneEntity : BaseEntity
    {
        public int ContactId { get; set; }

        public string Number { get; set; }

        public int Type { get; set; }
    }
}
