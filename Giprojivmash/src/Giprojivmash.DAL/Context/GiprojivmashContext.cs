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

        public virtual DbSet<PageEntity> Pages { get; set; }

        public virtual DbSet<ServiceFirstLayerEntity> ServiceFirstLayers { get; set; }

        public virtual DbSet<ServiceSecondLayerEntity> ServiceSecondLayers { get; set; }

        public virtual DbSet<ServiceThirdLayerEntity> ServiceThirdLayers { get; set; }

        public virtual DbSet<ContactEntity> Contacts { get; set; }

        public virtual DbSet<ContactDataEntity> ContactDatas { get; set; }

        public virtual DbSet<HistoryEntity> Histories { get; set; }

        public virtual DbSet<HistoryPhotoEntity> HistoryPhotos { get; set; }

        public virtual DbSet<PortfolioEntity> Portfolios { get; set; }

        public virtual DbSet<PortfolioPhotoEntity> PortfolioPhotos { get; set; }

        public virtual DbSet<VacancyEntity> Vacancies { get; set; }

        public virtual DbSet<DepartmentEntity> Departments { get; set; }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return new DbContextOptionsBuilder().UseMySQL(connectionString).Options;
        }
    }
}
