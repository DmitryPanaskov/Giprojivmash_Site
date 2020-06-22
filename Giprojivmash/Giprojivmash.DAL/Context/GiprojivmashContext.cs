using Giprojivmash.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Giprojivmash.DAL.Context
{
    public class GiprojivmashContext : DbContext
    {
        public GiprojivmashContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<ServiceFirstLayerEntity> ServiceFirstLayers { get; set; }

        public virtual DbSet<ServiceSecondLayerEntity> ServiceSecondLayers { get; set; }

        public virtual DbSet<ServiceThirdLayerEntity> ServiceThirdLayers { get; set; }
    }
}
