using System.ComponentModel.DataAnnotations;

namespace Traslado_Seguro.Models
{
	public class Conductor
	{
		public int Id { get; set; }
		[Required]
		public string Name { get; set; }
		[Required]
		[DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }
	}
}
