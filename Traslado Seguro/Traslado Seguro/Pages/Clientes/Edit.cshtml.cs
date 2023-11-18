using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Traslado_Seguro.Data;
using Traslado_Seguro.Models;

namespace Traslado_Seguro.Pages.Clientes
{
    public class EditModel : PageModel
    {
		private readonly TrasladoSeguroContext _context;
		public EditModel(TrasladoSeguroContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Cliente Cliente { get; set; } = default!;
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
			Cliente = cliente;
			return Page();
		}
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			_context.Attach(Cliente).State = EntityState.Modified;
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ClientExists(Cliente.Id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
			return RedirectToPage("./Index");
		}
		private bool ClientExists(int id)
		{
			return (_context.Clientes?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
