using MaktabTaha.Application.Interfaces.Repositories;
using MaktabTaha.Application.Interfaces.Repositories.BaseEntities;
using MaktabTaha.Application.Profiles;
using MaktabTaha.Domain.Common;
using MaktabTaha.Infrastructure.Repositories;
using MaktabTaha.Infrastructure.Repositories.baseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MaktabTaha.Infrastructure
{
    public class ApplicationConfiguration
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));

            //services.AddAutoMapper(config =>{},typeof(ApplicationConfiguration).Assembly);
            services.AddAutoMapper(config => { }, typeof(GenericProfile));
            services.AddTransient<IPasswordHasher, PasswordHasher>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPermissionRepository, PermissionRepository>();
            services.AddTransient<IRolePermissionRepository, RolePermissionRepository>();
            services.AddTransient<IRoleRepository, RoleRepository>();
            services.AddTransient<IRequestRepository, RequestRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<IAttachmentRepository, AttachmentRepository>();


            services.AddScoped<ITokenServices, TokenService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            //Base Entities

            services.AddTransient<IAreaRepository, AreaRepository>();
            services.AddTransient<IBankRepository, BankRepository>();
            services.AddTransient<ICaseTypeRepository, CaseTypeRepository>();
            services.AddTransient<ICharityMainRoleRepository, CharityMainRoleRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IEducationLevelRepository, EducationLevelRepository>();
            services.AddTransient<IEducationStatusRepository, EducationStatusRepository>();
            services.AddTransient<IEmploymentStatusRepository, EmploymentStatusRepository>();
            services.AddTransient<IGoodWorkTypeRepository, GoodWorkTypeRepository>();
            services.AddTransient<IHouseHeadStatusRepository, HouseHeadStatusRepository>();
            services.AddTransient<IHousingStatusRepository, HousingStatusRepository>();
            services.AddTransient<IJobRepository, JobRepository>();
            services.AddTransient<INationalityRepository, NationalityRepository>();
            services.AddTransient<IOrphanStatusRepository, OrphanStatusRepository>();
            services.AddTransient<IPhysicalStatusRepository, PhysicalStatusRepository>();
            services.AddTransient<IPrivatenessStatusRepository, PrivatenessStatusRepository>();
            services.AddTransient<IProvinceRepository, ProvinceRepository>();
            services.AddTransient<IRelationRepository, RelationRepository>();
            services.AddTransient<IReligonRepository, ReligonRepository>();
            services.AddTransient<IRequestTypeRepository, RequestTypeRepository>();
            services.AddTransient<ISkillRepository, SkillRepository>();
            services.AddTransient<IUnemploymentReasonRepository, UnemploymentReasonRepository>();
            services.AddTransient<IRequestStatusRepository, RequestStatusRepository>();
            services.AddTransient<ICaseStageRepository, CaseStageRepository>();
            services.AddTransient<IDependancyStatusRepository, DependancyStatusRepository>();
            services.AddTransient<IGenderRepository, GenderRepository>();
            services.AddTransient<IMaritalStatusRepository, MaritalStatusRepository>();
            services.AddTransient<ICaseRepository, CaseRepository>();
            services.AddTransient<ICaseStageRepository, CaseStageRepository>();
            services.AddTransient<ICasePersonRepository, CasePersonRepository>();
            services.AddTransient<IMoshaverehRepository, MoshaverehRepository>();



            services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
