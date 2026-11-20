using MaktabTaha.Application.DTO_s.onvaniPage.List;
using MaktabTaha.Application.DTO_s.onvaniPage.Search;
using MaktabTaha.Application.DTO_s.onvaniPage.Single;
using MaktabTaha.Domain.Entites;

namespace MaktabTaha.Application.Interfaces.Repositories
{
    public interface IOnvaniPageRepository : IGenericRepository<int, OnvaniPage>
    {
        Task<List<OnvaniPageBeforeApprovalDTO>> GetOnvaniPagesBeforeApprovalSearch(SearchOnvaniPageBeforeApprovalDTO Filters);
        Task<List<OnvaniPageBeforeManagerAcceptDTO>> GetOnvaniPagesBeforeManagerAcceptSearch(SearchOnvaniPageBeforeManagerAcceptDTO Filters);
        Task<SingleOnvaniPageDTO> GetOnvaniPageDetails(int id);

        Task<OnvaniPageMainListDTO> GetOnvaniPageMainList(string CaseNumber);
    }
}
