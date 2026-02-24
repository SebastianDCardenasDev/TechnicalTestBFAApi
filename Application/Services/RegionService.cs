using Application.DTOs;

namespace Application.Services
{
    public class RegionService(IRegionRepository regionRepository) : IRegionService
    {
        #region Globals
        private readonly IRegionRepository _regionRerpository = regionRepository;
        #endregion

        #region Methods Async
        public async Task<ApiResponse<List<RegionDto>>> GetAllRegionsAsync()
            => await _regionRerpository.GetAllRegionsAsync();

        public async Task<ApiResponse<RegionDto>> GetRegionByIdAsync(int idRegion)
            => await _regionRerpository.GetRegionByIdAsync(idRegion);

        public async Task<ApiResponse<string>> CreateRegionAsync(RegionDto RegionDto)
            => await _regionRerpository.CreateRegionAsync(RegionDto);

        public async Task<ApiResponse<string>> UpdateRegionAsync(RegionDto RegionDto)
            => await _regionRerpository.UpdateRegionAsync(RegionDto);

        public async Task<ApiResponse<string>> DeleteRegionAsync(int idRegion)
            => await _regionRerpository.DeleteRegionAsync(idRegion);
        #endregion
    }
}
