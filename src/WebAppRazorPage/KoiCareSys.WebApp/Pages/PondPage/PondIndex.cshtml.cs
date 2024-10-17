using KoiCareSys.WebApp.ApiService.Interface;
using KoiCareSys.WebApp.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiCareSys.WebApp.Pages.PondPage
{
    public class PondIndexModel : PageModel
    {
        private readonly IApiService _apiService;

        public PondIndexModel(IApiService apiService)
        {
            _apiService = apiService;
        }

        public List<PondDto> Ponds { get; set; }
        public async Task OnGetAsync()
        {
            try
            {
                Ponds = await _apiService.GetAsync<List<PondDto>>("api/pond");

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching ponds: {ex.Message}");
            }
        }
    }
}
