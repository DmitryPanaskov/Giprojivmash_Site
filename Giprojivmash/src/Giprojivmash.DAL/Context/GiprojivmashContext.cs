using Giprojivmash.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Giprojivmash.DAL.Context
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Major Code Smell", "S125:Sections of code should not be commented out", Justification = "<>")]
    public class GiprojivmashContext : DbContext
    {
        public GiprojivmashContext(DbContextOptions options)
            : base(options)
        {
        }

        public GiprojivmashContext(string connectionString)
            : base(GetOptions(connectionString))
        {
        }

        public virtual DbSet<ServiceFirstLayerEntity> ServiceFirstLayers { get; set; }

        public virtual DbSet<ServiceSecondLayerEntity> ServiceSecondLayers { get; set; }

        public virtual DbSet<ServiceThirdLayerEntity> ServiceThirdLayers { get; set; }

        public virtual DbSet<ContactEntity> Contact { get; set; }

        public virtual DbSet<ContactDataEntity> ContactData { get; set; }

        public virtual DbSet<HistoryEntity> History { get; set; }

        public virtual DbSet<HistoryPhotoEntity> HistoryPhoto { get; set; }

        public virtual DbSet<PortfolioEntity> Portfolio { get; set; }

        public virtual DbSet<PortfolioPhotoEntity> PortfolioPhoto { get; set; }

        public virtual DbSet<VacancyEntity> Vacancy { get; set; }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return new DbContextOptionsBuilder().UseMySQL(connectionString).Options;
        }
    }
}
