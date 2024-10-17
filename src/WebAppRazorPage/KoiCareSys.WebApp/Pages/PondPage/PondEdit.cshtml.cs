using KoiCareSys.WebApp.ApiService.Interface;
using KoiCareSys.WebApp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KoiCareSys.WebApp.Pages.PondPage
{
    public class PondEditModel : PageModel
    {
        private readonly IApiService _apiService;

        public PondEditModel(IApiService apiService)
        {
            _apiService = apiService;
        }

        [BindProperty]
        public PondDto Pond { get; set; } = default!;

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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                //Pond = await _apiService.GetAsync<PondDto>($"api/pond/{Pond.Id}");
                var result = await _apiService.PutAsync<PondDto>("api/pond", Pond);

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
