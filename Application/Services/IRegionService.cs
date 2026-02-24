using Application.DTOs;

namespace Application.Services
{
    public interface IRegionService
    {
        Task<ApiResponse<List<RegionDto>>> GetAllRegionsAsync();
        Task<ApiResponse<RegionDto>> GetRegionByIdAsync(int idRegion);
        Task<ApiResponse<string>> CreateRegionAsync(RegionDto RegionDto);
        Task<ApiResponse<string>> UpdateRegionAsync(RegionDto RegionDto);
        Task<ApiResponse<string>> DeleteRegionAsync(int idRegion);
    }
}
