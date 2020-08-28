using System.ComponentModel.DataAnnotations.Schema;

namespace Giprojivmash.DAL.Entities
{
    [Table("department")]
    public class DepartmentEntity : BaseEntity
    {
        public string Name { get; set; }
    }
}
