using Application.Const;
using Application.DTOs;
using Application.Services;
using System.Net.Http.Json;

namespace ExternalServices.Adapters.RegionApi
{
    public class RegionApiService(HttpClient httpClient, IRegionRepository regionRepository) : IRegionApiService
    {
        private readonly HttpClient _httpClient = httpClient;
        private readonly IRegionRepository _regionRepository = regionRepository;

        public async Task<ApiResponse<List<RegionDto>>> GetRegionAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("Region");

                if (!response.IsSuccessStatusCode)
                    return new ApiResponse<List<RegionDto>>(false, $"Error al consumir API: {response.StatusCode}");

                var result = await response.Content.ReadFromJsonAsync<List<RegionDto>>();

                if (result!.Count != 0)
                {
                    foreach (var region in result)
                    {
                        if(_regionRepository.GetRegionByNameAsync(region.Name).Result.Data)
                            await _regionRepository.CreateRegionAsync(region);
                    }

                    return new ApiResponse<List<RegionDto>>(true, string.Empty, result);
                }
                else
                    return new ApiResponse<List<RegionDto>>(false, ApplicationConst.RegionsNotFound);
            }
            catch (HttpRequestException ex)
            {
                return new ApiResponse<List<RegionDto>>(false, $"Error de conexión con la API: {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<RegionDto>>(false, $"Error inesperado: {ex.Message}");
            }
        }

        public async Task<ApiResponse<RegionDto>> GetRegionIdAsync(int idRegion)
        {
            try
            {
                var response = await _httpClient.GetAsync($"Region/{idRegion}");

                if (!response.IsSuccessStatusCode)
                    return new ApiResponse<RegionDto>(false, $"Error al consumir API: {response.StatusCode}");

                var result = await response.Content.ReadFromJsonAsync<RegionDto>();

                if (result != null)
                {
                    return new ApiResponse<RegionDto>(true, ApplicationConst.Empty, result);
                }
                else
                    return new ApiResponse<RegionDto>(false, ApplicationConst.RegionsNotFound);
            }
            catch (HttpRequestException ex)
            {
                return new ApiResponse<RegionDto>(false, $"Error de conexión con la API: {ex.Message}");
            }
            catch (Exception ex)
            {
                return new ApiResponse<RegionDto>(false, $"Error inesperado: {ex.Message}");
            }
        }
    }
}
