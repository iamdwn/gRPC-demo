using KoiCareSys.WebApp.ApiService.Interface;
using KoiCareSys.WebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiCareSys.WebApp.Pages.PondPage
{
    public class PondDeleteModel : PageModel
    {
        private readonly IApiService _apiService;

        [BindProperty]
        public PondDto Pond { get; set; } = default!;

        public PondDeleteModel(IApiService apiService)
        {
            _apiService = apiService;
        }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToPage("/PondPage/PondIndex");
            }

            try
            {
                Pond = await _apiService.GetAsync<PondDto>($"api/pond/{id}");

                if (Pond == null)
                {
                    return RedirectToPage("/PondPage/PondIndex");
                }
            }
            catch
            {
                return RedirectToPage("/PondPage/PondIndex");
            }

            return Page();
        }


        public async Task<IActionResult> OnPostAsync(Guid id)
        {
            try
            {
                Pond = await _apiService.GetAsync<PondDto>($"api/pond/{id}");
                var result = await _apiService.DeleteAsync<PondDto>($"api/pond/{Pond.Id}");

                if (result == null)
                {
                    return RedirectToPage("/PondPage/PondIndex");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while deleting the pond.");
                }
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "An error occurred.");
            }

            return RedirectToPage("/PondPage/PondIndex"); ;
        }

    }
}
