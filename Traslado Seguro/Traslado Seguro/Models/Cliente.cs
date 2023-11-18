namespace Traslado_Seguro.Models
{
	public class Cliente
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public ICollection<ServicioTransporte> ServicioTransporte { get; set; }
	}
}
