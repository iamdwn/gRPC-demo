using KoiCareSys.WebApp.ApiService.Interface;
using KoiCareSys.WebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiCareSys.WebApp.Pages.PondPage
{
    public class PondCreateModel : PageModel
    {
        private readonly IApiService _apiService;

        [BindProperty]
        public PondDto Pond { get; set; }

        public PondCreateModel(IApiService apiService)
        {
            _apiService = apiService;
        }

        public void OnGet()
        {
            // Initialize form (if necessary)
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var result = await _apiService.PostAsync<PondDto>("api/pond", Pond);

                if (result != null)
                {
                    return RedirectToPage("/PondPage/PondIndex");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "An error occurred while creating the pond.");
                }
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "An error occurred.");
            }

            return Page();
        }
    }
}
