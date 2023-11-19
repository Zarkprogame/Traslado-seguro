using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Traslado_Seguro.Data;
using Traslado_Seguro.Models;

namespace Traslado_Seguro.Pages.ServicioTransporte
{
    public class DeleteModel : PageModel
    {
		private readonly TrasladoSeguroContext _context;
		public DeleteModel(TrasladoSeguroContext context)
		{
			_context = context;
		}

		[BindProperty]
		public Models.ServicioTransporte ServicioTransporte { get; set; } = default!;
		public async Task<IActionResult> OnGetAsync(int? id)
		{
			if (id == null || _context.ServiciosTransportes == null)
			{
				return NotFound();
			}
			var service = await _context.ServiciosTransportes.FirstOrDefaultAsync(m => m.Id == id);

			if (service == null)
			{
				return NotFound();
			}
			else
			{
				ServicioTransporte = service;
			}
			return Page();
		}
		public async Task<IActionResult> OnPostAsync(int? id)
		{
			if (id == null || _context.ServiciosTransportes == null)
			{
				return NotFound();
			}
			var service = await _context.ServiciosTransportes.FindAsync(id);
			if (service != null)
			{
				ServicioTransporte = service;
				_context.ServiciosTransportes.Remove(ServicioTransporte);
				await _context.SaveChangesAsync();
			}
			return RedirectToPage("./Index");
		}
	}
}
