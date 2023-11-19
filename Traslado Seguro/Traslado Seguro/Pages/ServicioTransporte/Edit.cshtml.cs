using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Traslado_Seguro.Data;
using Traslado_Seguro.Models.ViewModel;

namespace Traslado_Seguro.Pages.ServicioTransporte
{
    public class EditModel : PageModel
    {
		private readonly TrasladoSeguroContext _context;
		public EditModel(TrasladoSeguroContext context)
		{
			_context = context;
		}

		[BindProperty]
		public CreateService service { get; set; }
		public async Task<IActionResult> OnGet(int id)
		{
			service = new CreateService()
			{
				ClientList = await _context.Clientes.ToListAsync(),
				ServicioTransporte = await _context.ServiciosTransportes.FindAsync(id)
			};
			return Page();
		}
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (!ModelState.IsValid)
			{
				return Page();
			}
			_context.Attach(service.ServicioTransporte).State = EntityState.Modified;
			try
			{
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!ServiceExists(service.ServicioTransporte.Id))
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
		private bool ServiceExists(int id)
		{
			return (_context.ServiciosTransportes?.Any(e => e.Id == id)).GetValueOrDefault();
		}
	}
}
