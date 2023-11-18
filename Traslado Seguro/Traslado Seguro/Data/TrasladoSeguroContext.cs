using Microsoft.EntityFrameworkCore;
using System;
using Traslado_Seguro.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Traslado_Seguro.Data
{
	public class TrasladoSeguroContext: DbContext
	{
		public TrasladoSeguroContext(DbContextOptions options) : base(options)
		{
		}
		public DbSet<Conductor> Conductores { get; set; }
		public DbSet<Cliente> Clientes { get; set; }
		public DbSet<ServicioTransporte> ServiciosTransportes { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(
				"Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = TrasladoSeguroDB; Integrated Security = True; Connect Timeout = 30; Encrypt = False; Trust Server Certificate = False; Application Intent = ReadWrite; Multi Subnet Failover = False"
				);
		}
	}
}
