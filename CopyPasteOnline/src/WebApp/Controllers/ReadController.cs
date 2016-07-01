using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MBODM.CopyPasteUI.Classes;
using MBODM.CopyPasteUI.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MBODM.CopyPasteUI.Controllers
{
    public class ReadController : Controller
    {
        public IActionResult Index()
        {
            return View(new ReadViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ReadViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await httpClient.GetAsync(new Uri(AppInfos.WebApiUrl) + "/" + model.ID);

                    if (response.IsSuccessStatusCode)
                    {
                        var text = await response.Content.ReadAsStringAsync();

                        return View(new ReadViewModel() { Text = text });
                    }
                    else
                    {
                        return View(new ReadViewModel() { Error = (int)response.StatusCode });
                    }
                }
            }
            else
            {
                return View(new ReadViewModel());
            }
        }
    }
}
