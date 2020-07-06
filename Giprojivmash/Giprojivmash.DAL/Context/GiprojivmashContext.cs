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

        public virtual DbSet<ContactEntity> Contact { get; set; }

        public virtual DbSet<ContactPhoneEntity> ContactPhone { get; set; }

        public virtual DbSet<HistoryEntity> History { get; set; }

        public virtual DbSet<HistoryPhotoEntity> HistoryPhoto { get; set; }

        public virtual DbSet<PortfolioEntity> Portfolio { get; set; }

        public virtual DbSet<PortfolioPhotoEntity> PortfolioPhoto { get; set; }

        public virtual DbSet<VacancyEntity> Vacancy { get; set; }
    }
}
