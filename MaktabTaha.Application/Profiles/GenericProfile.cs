using AutoMapper;
using MaktabTaha.Application.DTO_s.Requests.List;
using MaktabTaha.Application.DTO_s.users.list;
using MaktabTaha.Application.DTO_s.users.single;
using MaktabTaha.Application.Features.request.Command.Approve;
using MaktabTaha.Application.Features.request.Command.Create;
using MaktabTaha.Application.Features.request.Command.Update;
using MaktabTaha.Application.Features.permission.Command.Create;
using MaktabTaha.Application.Features.permission.Command.Delete;
using MaktabTaha.Application.Features.permission.Command.Update;
using MaktabTaha.Application.Features.role.Command.create;
using MaktabTaha.Application.Features.role.Command.delete;
using MaktabTaha.Application.Features.role.Command.update;
using MaktabTaha.Application.Features.role_permission.Command.Create;
using MaktabTaha.Application.Features.role_permission.Command.Delete;
using MaktabTaha.Application.Features.role_permission.Command.Update;
using MaktabTaha.Application.Features.user.Command.Create;
using MaktabTaha.Application.Features.user.Command.delete;
using MaktabTaha.Application.Features.user.Command.update;
using MaktabTaha.Domain.Common;
using MaktabTaha.Domain.Entites;
using MaktabTaha.Application.DTO_s.Requests.Single;
using MaktabTaha.Application.Features.person.Command.Create;
using MaktabTaha.Application.Features.person.Command.Update;
using MaktabTaha.Application.DTO_s.person.List;
using MaktabTaha.Application.DTO_s.person.Single;
using MaktabTaha.Application.Features.attachment.Command.Update;
using MaktabTaha.Application.Features.attachment.Query.List;
using MaktabTaha.Application.Features.attachment.Query.Single;
using MaktabTaha.Application.Features.caseDesc.Command.Create;
using MaktabTaha.Application.Features.caseDesc.Command.Update;
using MaktabTaha.Application.DTO_s.caseDesc.Single;
using MaktabTaha.Application.Features.casePerson.Command.Create;
using MaktabTaha.Application.Features.casePerson.Command.Update;
using MaktabTaha.Application.DTO_s.casePerson.List;
using MaktabTaha.Application.DTO_s.casePerson.Single;
using MaktabTaha.Application.DTO_s.caseDesc.List;
using MaktabTaha.Application.DTO_s.person.Search;
using MaktabTaha.Application.Features.moshavereh.Command.Create;
using MaktabTaha.Application.Features.moshavereh.Command.Update;
using MaktabTaha.Application.DTO_s.Moshavereh.Single;
using MaktabTaha.Application.DTO_s.Moshavereh.Update;
using MaktabTaha.Application.Features.caseDesc.Query.Single;
using MaktabTaha.Application.Features.tahghigh.Command.Create;
using MaktabTaha.Application.Features.tahghigh.Command.Update;
using MaktabTaha.Application.DTO_s.tahghigh.Update;
using MaktabTaha.Application.DTO_s.tahghigh.Single;
using MaktabTaha.Application.Features.donor.Command.Create;
using MaktabTaha.Application.Features.donor.Command.Update;

namespace MaktabTaha.Application.Profiles
{
    public class GenericProfile : Profile
    {
        public GenericProfile()
        {
            //USER
            CreateMap<CreateUserCommand, User>();
            CreateMap<UpdateUserCommand, User>()
                .ForMember(dest => dest.UserName, opt => opt.Ignore())
                .ForMember(dest => dest.LastEntry, opt => opt.Ignore())
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
            CreateMap<DeleteUserCommand, User>();
            CreateMap<AuthViewModel, User>();

            CreateMap<User, UserListDTO>();
            CreateMap<User, UserSingleDTO>();

            //PERMISSION
            CreateMap<CreatePermissionCommand, Permission>();
            CreateMap<UpdatePermissionCommand, Permission>();
            CreateMap<DeletePermissionCommand, Permission>();

            //ROLE PERMISSION
            CreateMap<CreateRolePermissionCommand, RolePermission>();
            CreateMap<UpdateRolePermissionCommand, RolePermission>();
            CreateMap<DeleteRolePermissionCommand, RolePermission>();

            //Request
            CreateMap<CreateRequestCommand, Request>();
            CreateMap<UpdateRequestCommand, Request>();
            CreateMap<Request, RequestListDTO>()
                .ForMember(
                    dest => dest.RequestTypeTitle,
                    opt => opt.MapFrom(src => src.RequestType != null
                        ? src.RequestType.RequestTypeName
                        : null)
                )
                .ForMember(
                    dest => dest.HouseHeadStatusTitle,
                    opt => opt.MapFrom(src => src.HouseHeadStatus != null
                        ? src.HouseHeadStatus.Name
                        : null)
                )
                .ForMember(
                    dest => dest.RefererName,
                    opt => opt.MapFrom(src => src.Referer != null
                        ? $"{src.Referer.Firstname} {src.Referer.Lastname}"
                        : null)
                )
                .ForMember(
                    dest => dest.NationaltyTitle,
                    opt => opt.MapFrom(src => src.Nationalty != null
                        ? src.Nationalty.NationalityName
                        : null)
                )
                .ForMember(
                    dest => dest.ProvinceTitle,
                    opt => opt.MapFrom(src => src.Province != null
                        ? src.Province.ProvinceName
                        : null)
                )
                .ForMember(
                    dest => dest.CityTitle,
                    opt => opt.MapFrom(src => src.City != null
                        ? src.City.CityName
                        : null)
                )
                .ForMember(
                    dest => dest.AreaTitle,
                    opt => opt.MapFrom(src => src.Area != null
                        ? src.Area.AreaName
                        : null)
                )
                .ForMember(
                    dest => dest.ReligonTitle,
                    opt => opt.MapFrom(src => src.Religon != null
                        ? src.Religon.ReligonName
                        : null)
                )
                .ForMember(
                    dest => dest.RequestStatusTitle,
                    opt => opt.MapFrom(src => src.RequestStatus != null
                        ? src.RequestStatus.RequestStatusName
                        : null)
                )
                .ForMember(
                    dest => dest.FullName,
                    opt => opt.MapFrom(src =>
                        $"{src.ClientFirstName} {src.ClientLastName}".Trim()
                    )
                ); 
            CreateMap<Request, RequestSingleDTO>();
            CreateMap<ApproveRequestCommand, Request>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Attachment, opt => opt.Ignore());

            //ROLE
            CreateMap<CreateRoleCommand, Role>();
            CreateMap<UpdateRoleCommand, Role>();
            CreateMap<DeleteRoleCommand, Role>();

            // Person
            CreateMap<CreatePersonCommand, Person>();
            CreateMap<UpdatePersonCommand,  Person>();
            CreateMap<Person, PersonListDTO>()
                .ForMember(
                    dest => dest.GenderTitle,
                    opt => opt.MapFrom(src => src.Gender != null
                    ? src.Gender.GenderName
                    : null));
            CreateMap<Person, PersonSingleDTO>();
            CreateMap<Person, SearchCasePersonListDTO>();

            // Attachment
            CreateMap<UpdateAttachmentCommand, Attachments>()
                .ForMember(dest => dest.Attach, opt => opt.Ignore());
            CreateMap<Attachments, GetAttachmentListCommand>();
            CreateMap<Attachments, GetSingleAttachmentCommand>();

            // Case
            CreateMap<CreateCaseCommand, Case>();
            CreateMap<UpdateCaseCommand, Case>();
            CreateMap<Case, CaseSingleDTO>();
            

            // CasePerosn
            CreateMap<CreateCasePersonCommand, CasePerson>();
            CreateMap<UpdateCasePersonCommand, CasePerson>();
            CreateMap<CasePerson, CasePersonSingleDTO>();
            CreateMap<CasePerson, CasePersonListDTO>();



            // Moshavereh
            CreateMap<CreateMoshaverehcCommand, Moshavereh>();
            CreateMap<Moshavereh, MoshaverehSingleDTO>()
                .ForMember(dest => dest.MoshaverehDate,
                            opt => opt.MapFrom(src => src.CreatedDate))
                .ForMember(dest => dest.Id,
                            opt => opt.MapFrom(src => src.Id));
            CreateMap<UpdateMoshaverehCommand, Moshavereh>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.MoshaverehDate, opt => opt.Ignore());
            CreateMap<Moshavereh, UpdateMoshaverehDTO>();


            // Tahgigh
            CreateMap<CreateTahghighCommand, Tahghigh>();
            CreateMap<UpdateTahghighCommand, Tahghigh>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.TahghighDate, opt => opt.Ignore());
            CreateMap<Tahghigh, UpdateTahghighDTO>();


            // Donor
            CreateMap<CreateDonorCommand, Donor>();
            CreateMap<UpdateDonorCommand, Donor>();

        }
    }
}
