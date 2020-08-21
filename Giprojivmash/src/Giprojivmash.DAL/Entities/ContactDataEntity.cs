using System.ComponentModel.DataAnnotations.Schema;
using Giprojivmash.DataModels.Enums;

namespace Giprojivmash.DAL.Entities
{
    [Table("contactdata")]
    public class ContactDataEntity : BaseEntity
    {
        public int ContactId { get; set; }

        public string Data { get; set; }

        public string SubData { get; set; }

        public ContactDataType ContactDataType { get; set; }
    }
}
