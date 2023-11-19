using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Traslado_Seguro.Data;
using Traslado_Seguro.Models;

namespace Traslado_Seguro.Pages.ServicioTransporte
{
	[Authorize]
	public class IndexModel : PageModel
    {
		private readonly TrasladoSeguroContext _context;
		public IndexModel(TrasladoSeguroContext context)
		{
			_context = context;
		}
		public IEnumerable<Models.ServicioTransporte> ServiciosTransportes { get; set; }
		public async Task OnGet()
		{
			ServiciosTransportes = await _context.ServiciosTransportes.Include(c => c.Cliente).ToListAsync();
		}
	}
}
