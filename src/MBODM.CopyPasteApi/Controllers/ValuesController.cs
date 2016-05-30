using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MBODM.CopyPasteApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MBODM.CopyPasteApi.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IRepository repository;

        public ValuesController(IRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("{id}")]
        public IActionResult Read(int id)
        {
            var text = repository.Find(id);

            if (!string.IsNullOrEmpty(text))
            {
                return new ObjectResult(text);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody]string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                var id = repository.Add(text);

                return CreatedAtRoute(new { controller = "Values", id = id }, text);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (repository.Remove(id))
            {
                return new NoContentResult();
            }
            else
            {
                return NotFound();
            }
        }
    }
}
