using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace event_registrator.Controllers
{
    public class ufController : Controller
    {
		//public IActionResult Index()
		//{
		//    return View();
		//}

		private readonly IWebHostEnvironment _appEnvironment;
		public ufController(IWebHostEnvironment appEnvironment)
		{
			_appEnvironment = appEnvironment;
		}



		[HttpPost("uf")]
		public async Task<IActionResult> Index(List<IFormFile> files)
		{

			long size = files.Sum(f => f.Length);

			var filePaths = new List<string>();
			foreach (var formFile in files)
			{
				if (formFile.Length > 0)
				{
					var time = DateTime.Now.Ticks;
					var fns = formFile.FileName.Split('.');
					var fn = fns[0];
					var ras = fns[1];
					string target = _appEnvironment.ContentRootPath + "//wwwroot//TempFiles";
					if (!Directory.Exists(target))
					{
						Directory.CreateDirectory(target);
					}
					string file_path = Path.Combine(target, fn +  "." + ras);
					string cur_file_path = "";
					if (System.IO.File.Exists(file_path)) {
						cur_file_path = Path.Combine(target, fn );
						int count = 1;
						while (true)
						{
							if(!System.IO.File.Exists(cur_file_path + count.ToString() + "." + ras))
							{
								file_path = cur_file_path + count.ToString() + "." + ras;
								break;
							}
							else count++;
						}
					}

					filePaths.Add(file_path);

					//using (var stream = new FileStream(filePath, FileMode.Create))
					using (var stream = new FileStream(file_path, FileMode.Create))
					{
						await formFile.CopyToAsync(stream);
					}
				}
			}

			// process uploaded files
			// Don't rely on or trust the FileName property without validation.
			return Ok(new { count = files.Count, size, filePaths, message = "ok" });
		}




	}
}