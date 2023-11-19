using System.ComponentModel.DataAnnotations;

namespace Traslado_Seguro.Models
{
	public class ServicioTransporte
	{
		public int Id { get; set; }

		[DataType(DataType.Date)]
		[Display(Name =	"Creation Date")]
		public DateTime? Fecha { get; set;}

		[Display(Name = "Conductor Name")]
		[Required(ErrorMessage = "The Conductor Name is required")]
		public string NameConductor{ get; set; }

		public int ClienteId { get; set; }
		public Cliente Cliente { get; set;}
	}
}
