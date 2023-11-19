using System.ComponentModel.DataAnnotations;

namespace Traslado_Seguro.Models
{
	public class Cliente
	{
		public int Id { get; set; }
		[Required(ErrorMessage ="The Name is required")]
		public string Name { get; set; }
		public ICollection<ServicioTransporte> ServicioTransporte { get; set; }
	}
}
