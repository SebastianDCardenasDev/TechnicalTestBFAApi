using Application.Const;
using Application.DTOs;
using Application.Services;
using ExternalServices.Adapters.RegionApi;
using Microsoft.AspNetCore.Mvc;

namespace TechnicalTestBFAApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class regionController(IRegionService regionService, IRegionApiService regionApiService) : ControllerBase
    {
        #region Globals
        private readonly IRegionService _regionService = regionService;
        private readonly IRegionApiService _regionApiService = regionApiService;
        #endregion

        #region Services
        [HttpGet("allregions")]
        public async Task<IActionResult> GetAllregionAsync()
        {
            try
            {
                var response = await _regionService.GetAllRegionsAsync();

                if (response.Status)
                    return new OkObjectResult(response);
                else
                    return new BadRequestObjectResult(response);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new ApiResponse<string>(false, ex.Message));
            }
        }

        [HttpGet("getregionbyid/{idRegion}")]
        public async Task<IActionResult> GetRegionIdAsync([FromRoute] int idRegion)
        {
            try
            {
                var response = await _regionService.GetRegionByIdAsync(idRegion);

                if (response.Status)
                    return new OkObjectResult(response);
                else
                    return new BadRequestObjectResult(response);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new ApiResponse<string>(ApplicationConst.Bad, ex.Message));
            }
        }

        [HttpPost("createregion")]
        public async Task<IActionResult> CreateregionAsync(RegionDto regionDto)
        {
            try
            {
                var response = await _regionService.CreateRegionAsync(regionDto);

                if (response.Status)
                    return new OkObjectResult(response);
                else
                    return new BadRequestObjectResult(response);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new ApiResponse<string>(false, ex.Message));
            }
        }

        [HttpPut("updateregion")]
        public async Task<IActionResult> UpdateregionAsync(RegionDto regionDto)
        {
            try
            {
                var response = await _regionService.UpdateRegionAsync(regionDto);

                if (response.Status)
                    return new OkObjectResult(response);
                else
                    return new BadRequestObjectResult(response);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new ApiResponse<string>(false, ex.Message));
            }
        }

        [HttpDelete("deleteregion")]
        public async Task<IActionResult> DeleteregionAsync(int idregion)
        {
            try
            {
                var response = await _regionService.DeleteRegionAsync(idregion);

                if (response.Status)
                    return new OkObjectResult(response);
                else
                    return new BadRequestObjectResult(response);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new ApiResponse<string>(false, ex.Message));
            }
        }
        #endregion

        #region ExternalService
        [HttpGet("getregionsapi")]
        public async Task<IActionResult> GetRegionAsync()
        {
            try
            {
                var response = await _regionApiService.GetRegionAsync();

                if (response.Status)
                    return new OkObjectResult(response);
                else
                    return new BadRequestObjectResult(response);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new ApiResponse<string>(false, ex.Message));
            }
        }

        [HttpGet("getregionsbyidapi/{idRegion}")]
        public async Task<IActionResult> GetRegionByIdAsync([FromRoute] int idRegion)
        {
            try
            {
                var response = await _regionApiService.GetRegionIdAsync(idRegion);

                if (response.Status)
                    return new OkObjectResult(response);
                else
                    return new BadRequestObjectResult(response);
            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(new ApiResponse<string>(false, ex.Message));
            }
        }
        #endregion
    }
}
