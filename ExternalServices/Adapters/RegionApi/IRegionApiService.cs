using Application.DTOs;

namespace ExternalServices.Adapters.RegionApi
{
    public interface IRegionApiService
    {
        Task<ApiResponse<List<RegionDto>>> GetRegionAsync();
        Task<ApiResponse<RegionDto>> GetRegionIdAsync(int idRegion);
    }
}
