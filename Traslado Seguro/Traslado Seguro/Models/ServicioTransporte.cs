using System.ComponentModel.DataAnnotations;

namespace Traslado_Seguro.Models
{
	public class ServicioTransporte
	{
		public int Id { get; set; }

		[DataType(DataType.Date)]
		[Display(Name =	"Fecha de Creacion")]
		public DateTime? Fecha { get; set;}
		public string NameConductor{ get; set; }
		public int ClienteId { get; set; }
		public Cliente Cliente { get; set;}
	}
}
