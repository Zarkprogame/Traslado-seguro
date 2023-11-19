using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Traslado_Seguro.Data;
using Traslado_Seguro.Models.ViewModel;

namespace Traslado_Seguro.Pages.ServicioTransporte
{
    public class CreateModel : PageModel
    {
		private readonly TrasladoSeguroContext _context;
		public CreateModel(TrasladoSeguroContext context)
		{
			_context = context;
		}

		[BindProperty]
		public CreateService service { get; set; }
		public async Task<IActionResult> OnGet()
		{
			service = new CreateService()
			{
				ClientList = await _context.Clientes.ToListAsync(),
				ServicioTransporte = new Models.ServicioTransporte()
			};
			return Page();
		}
		public async Task<IActionResult> OnPost()
		{
			if (ModelState.IsValid)
			{
				await _context.ServiciosTransportes.AddAsync(service.ServicioTransporte);
				await _context.SaveChangesAsync();
				return RedirectToPage("./Index");
			}
			else
			{
				return Page();
			}
		}
	}
}
