using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Traslado_Seguro.Pages.Account
{
    public class LogoutModel : PageModel
    {
		public async Task<IActionResult> OnPostAsync()
		{
			await HttpContext.SignOutAsync("MyCookieAuth");
			return RedirectToAction("/Index");
		}
	}
}
