using Application.DTOs;

namespace Application.Services
{
    public interface IRegionRepository
    {
        Task<ApiResponse<List<RegionDto>>> GetAllRegionsAsync();
        Task<ApiResponse<RegionDto>> GetRegionByIdAsync(int idRegion);
        Task<ApiResponse<bool>> GetRegionByNameAsync(string name);
        Task<ApiResponse<string>> CreateRegionAsync(RegionDto RegionDto);
        Task<ApiResponse<string>> UpdateRegionAsync(RegionDto RegionDto);
        Task<ApiResponse<string>> DeleteRegionAsync(int idRegion);
    }
}
