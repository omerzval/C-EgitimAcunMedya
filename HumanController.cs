using Basics.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basics.Controllers
{
	public class HumanController : Controller
	{
		public IActionResult Index()	
		{
			var insan = new Human();
			insan.Id = 5;
			insan.Name = "Ömer Emir Zıvalı";

			return View(insan);
		}
		public IActionResult List()
		{
			var insanlar = new List<Human>()
			{
				new Human(){Id=1,Name="Ahmet Yaşar"},
				new Human(){Id=2,Name="Mehmet Yaşar"},
				new Human(){Id=3,Name="Veli Yaşar"},
				new Human(){Id=4,Name="Samet Yaşar"},


			};

			return View(insanlar);
		}
		
	}
}
