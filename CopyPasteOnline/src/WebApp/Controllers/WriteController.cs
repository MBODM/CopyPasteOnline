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
    public class WriteController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new WriteViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(WriteViewModel model)
        {
            if (ModelState.IsValid)
            {
                using (var httpClient = new HttpClient())
                {
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var response = await httpClient.PostAsJsonAsync(new Uri(AppInfos.WebApiUrl), model.Text);

                    if (response.IsSuccessStatusCode)
                    {
                        var id = int.Parse(response.
                            Headers.
                            Location.
                            ToString().
                            Split(new string[] { "?id=" }, StringSplitOptions.RemoveEmptyEntries).
                            Last());

                        return View(new WriteViewModel() { ID = id });
                    }
                    else
                    {
                        return View(new WriteViewModel() { Error = (int)response.StatusCode });
                    }
                }
            }
            else
            {
                return View(new WriteViewModel());
            }
        }
    }
}
