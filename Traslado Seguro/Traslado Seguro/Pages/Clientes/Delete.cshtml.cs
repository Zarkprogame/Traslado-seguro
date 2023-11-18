using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Traslado_Seguro.Data;
using Traslado_Seguro.Models;

namespace Traslado_Seguro.Pages.Clientes
{
    public class DeleteModel : PageModel
    {
		private readonly TrasladoSeguroContext _context;
		public DeleteModel(TrasladoSeguroContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Cliente Clientes { get; set; } = default!;
		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.Clientes == null)
			{
				return NotFound();
			}
			var cliente = await _context.Clientes.FirstOrDefaultAsync(m => m.Id == id);

			if (cliente == null)
			{
				return NotFound();
			}
			else
			{
				Clientes = cliente;
			}
			return Page();
		}
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.Clientes == null)
			{
				return NotFound();
			}
			var cliente = await _context.Clientes.FindAsync(id);
			if (cliente != null)
			{
				Clientes = cliente;
				_context.Clientes.Remove(Clientes);
				await _context.SaveChangesAsync();
			}
			return RedirectToPage("./Index");
		}
	}
}
