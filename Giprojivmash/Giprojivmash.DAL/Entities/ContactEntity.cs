using System.ComponentModel.DataAnnotations.Schema;

namespace Giprojivmash.DAL.Entities
{
    [Table("Contact")]
    public class ContactEntity : BaseEntity
    {
        public string Photo { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }
    }
}
