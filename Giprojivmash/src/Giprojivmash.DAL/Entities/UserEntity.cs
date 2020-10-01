using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Giprojivmash.DAL.Entities
{
    [Table("aspnetusers")]
    public class UserEntity : IdentityUser
    {
    }
}
