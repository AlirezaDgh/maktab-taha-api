using MaktabTaha.Domain.Entites;
using MaktabTaha.Domain.Entites.BaseEntities;

using Microsoft.EntityFrameworkCore;

namespace MaktabTaha.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }
        public DbSet<Request> Request { get; set; }
        public DbSet<Area> Area { get; set; }
        public DbSet<Bank> Bank { get; set; }
        public DbSet<CaseType> CaseType { get; set; }
        public DbSet<CharityMainRole> CharityMainRole { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<EducationLevel> EducationLevel { get; set; }
        public DbSet<EducationStatus> EducationStatus { get; set; }
        public DbSet<EmploymentStatus> EmploymantStatus { get; set; }
        public DbSet<GoodWorkType> GoodWorkType { get; set; }
        public DbSet<HouseHeadStatus> HouseHeadStatus { get; set; }
        public DbSet<HousingStatus> HousingStatus { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<Nationality> Nationality { get; set; }
        public DbSet<OrphanStatus> OrphanStatus { get; set; }
        public DbSet<PhysicalStatus> PhysicalStatus { get; set; }
        public DbSet<PrivatenessStatus> PrivatenessStatus { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<Religon> Religon { get; set; }
        public DbSet<Relation> Relation { get; set; }
        public DbSet<RequestType> RequestType { get; set; }
        public DbSet<Skill> Skill { get; set; }
        public DbSet<UnemploymentReason> UnemploymentReason { get; set; }
        public DbSet<RequestStatus> RequestStatus { get; set; }

        public DbSet<DependancyStatus> DependancyStatus {  get; set; }
        public DbSet<MaritalStatus> MaritalStatus { get; set; }
        public DbSet<CaseStage> CaseStage { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<Attachments> Attachment { get; set; }
        public DbSet<CasePerson> CasePerson { get; set; }
        public DbSet<Case> CaseBNF { get; set; }
        public DbSet<Moshavereh> Moshavereh { get; set; }
        public DbSet<Tahghigh> Tahghigh { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(ApplicationDbContext).Assembly
            );
        }
    }
}
