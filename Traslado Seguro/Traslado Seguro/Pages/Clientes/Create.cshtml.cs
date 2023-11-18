using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Traslado_Seguro.Data;
using Traslado_Seguro.Models;

namespace Traslado_Seguro.Pages.Clientes
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
		public Cliente Clientes { get; set; } = default!;
		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid || _context.Clientes == null || Clientes == null)
			{
				return Page();
			}
			_context.Clientes.Add(Clientes);
			await _context.SaveChangesAsync();

			return RedirectToPage("./Index");
		}
	}
}
