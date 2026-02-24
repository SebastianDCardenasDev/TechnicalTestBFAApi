using Application.Const;
using Application.DTOs;
using Application.Services;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAcces.Persistences.Repositories
{
    public class RegionRepository(DataBaseContext context) : IRegionRepository
    {
        #region Globals
        private readonly DataBaseContext _context = context;
        #endregion

        #region Methods Async
        public async Task<ApiResponse<List<RegionDto>>> GetAllRegionsAsync()
        {
            var getRegions = await GetAllRegions();
            if (getRegions.Count == 0) return new ApiResponse<List<RegionDto>>(false, ApplicationConst.RegionsNotFound);

            var regions = new List<RegionDto>();

            foreach (var item in getRegions!)
            {
                var patient = new RegionDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Description = item.Description,
                    Departament = item.Departament
                };

                regions.Add(patient);
            }

            return new ApiResponse<List<RegionDto>>(true, ApplicationConst.Empty, regions);
        }

        public async Task<ApiResponse<RegionDto>> GetRegionByIdAsync(int idRegion)
        {
            var getRegion = await GetRegionById(idRegion);
            if (getRegion == null) return new ApiResponse<RegionDto>(false, ApplicationConst.RegionsNotData);

            var region = new RegionDto()
            {
                Id = getRegion!.Id,
                Name = getRegion.Name,
                Description = getRegion.Description,
                Departament = getRegion.Departament
            };

            return new ApiResponse<RegionDto>(true, ApplicationConst.Empty, region);
        }

        public async Task<ApiResponse<bool>> GetRegionByNameAsync(string name)
        {
            var getRegion = await GetRegionByName(name);
            if (getRegion) return new ApiResponse<bool>(false, ApplicationConst.RegionsDuplicated, false);

            return new ApiResponse<bool>(true, ApplicationConst.RegionsNotData, true);
        }

        public async Task<ApiResponse<string>> CreateRegionAsync(RegionDto regionDto)
        {
            var getRegion = await GetRegionByName(regionDto.Name);
            if (getRegion) return new ApiResponse<string>(false, ApplicationConst.RegionsDuplicated);

            var newRegion = new Regions()
            {
                Name = regionDto.Name,
                Description = regionDto.Description,
                Departament = regionDto.Departament
            };

            _context.Regions.Add(newRegion);
            await _context.SaveChangesAsync();

            return new ApiResponse<string>(true, ApplicationConst.RegionsSuccess);
        }

        public async Task<ApiResponse<string>> UpdateRegionAsync(RegionDto regionDto)
        {
            var getRegion = await GetRegionById(regionDto.Id);
            if (getRegion == null) return new ApiResponse<string>(false, ApplicationConst.RegionsNotData);

            getRegion.Name = regionDto.Name;
            getRegion.Description = regionDto.Description;
            getRegion.Departament = regionDto.Departament;

            await _context.SaveChangesAsync();

            return new ApiResponse<string>(true, ApplicationConst.RegionsUpdate);
        }

        public async Task<ApiResponse<string>> DeleteRegionAsync(int idRegion)
        {
            var getRegion = await GetRegionById(idRegion);
            if (getRegion == null) return new ApiResponse<string>(false, ApplicationConst.RegionsNotData);

            _context.Remove(getRegion);
            await _context.SaveChangesAsync();

            return new ApiResponse<string>(true, ApplicationConst.RegionsDelete);
        }
        #endregion

        #region Consults DB
        private async Task<List<Regions>> GetAllRegions()
            => await _context.Regions
            .ToListAsync();

        private async Task<Regions?> GetRegionById(int idRegion)
            => await _context.Regions
            .FirstOrDefaultAsync(p => p.Id == idRegion);

        private async Task<bool> GetRegionByName(string name)
           => await _context.Regions.AnyAsync(g => g.Name == name);
        #endregion
    }
}
