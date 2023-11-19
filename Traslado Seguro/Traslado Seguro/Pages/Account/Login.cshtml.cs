using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Security.Claims;
using Traslado_Seguro.Models;

namespace Traslado_Seguro.Pages.Account
{
    public class LoginModel : PageModel
    {
		[BindProperty]
		public Conductor Conductor { get; set; }
		public string Name = "", Email = "", Password = "";

		public async Task<IActionResult> OnPostAsync()
		{
			if (!ModelState.IsValid) return Page();
			string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=TrasladoSeguroDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
			using (SqlConnection connection = new SqlConnection(connectionString))
			{
				connection.Open();

				using (SqlCommand command = new SqlCommand("SELECT Name, Email, Password FROM TrasladoSeguroDB.dbo.Conductor WHERE Email = '" + Conductor.Email + "'; ", connection))
				{
					using (SqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							Name = reader.GetString(0);
							Email = reader.GetString(1);
							Password = reader.GetString(2);
						}
					}
				}
				if (Conductor.Email == Email && Conductor.Password == Password)
				{
					var claims = new List<Claim> {
						new Claim(ClaimTypes.Name, Name),
						new Claim(ClaimTypes.Email, Conductor.Email),
					};
					var identity = new ClaimsIdentity(claims, "MyCookieAuth");
					ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);
					await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);
					return RedirectToPage("/index");
				}
				else
				{
					ViewData["Message"] = "Email or Password Incorrent, Please try again";
					ViewData["liveToastBtn"] = true;
					return Page();
				}
			}
		}
	}
}
