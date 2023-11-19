using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Traslado_Seguro.Data;
using Traslado_Seguro.Models;

namespace Traslado_Seguro.Pages.Register
{
    public class CreateModel : PageModel
    {
		private readonly TrasladoSeguroContext _context;
		public CreateModel(TrasladoSeguroContext context)
		{
			_context = context;
		}
		public IActionResult OnGet()
		{
			return Page();
		}

		[BindProperty]
		public Conductor Conductor { get; set; } = default!;
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Conductores == null || Conductor == null)
			{
				return Page();
			}
			_context.Conductores.Add(Conductor);
			await _context.SaveChangesAsync();

			return RedirectToPage("/Account/Login");
		}
	}
}
