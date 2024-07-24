using Biblioteca.BL.Interfaces;
using Biblioteca.Entities.DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Biblioteca.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorService service;

        public AutorController(IAutorService service)
        {
            this.service = service;
        }

        // GET: api/<AutorController>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AutorDTO>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]

        public async Task<IActionResult> GetAll()
        {
            IEnumerable<AutorDTO> result = (IEnumerable<AutorDTO>)await this.service.GetAutoresAsync();
            return (result != null && result.Any()) ? (IActionResult)this.Ok(result) : (IActionResult)this.NoContent();
        }

        // GET api/<AutorController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(AutorDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Get(int id)
        {
            AutorDTO result = (AutorDTO)await this.service.GetAutorByIdAsync(id);
            return (result != null) ? (IActionResult)this.Ok(result) : (IActionResult)this.NoContent();
        }

        // POST api/<AutorController>
        [HttpPost]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Post(AutorDTO model)
        {
            if (model == null)
            {
                return (IActionResult)this.BadRequest();
            }

            int result = await this.service.InsertAutorAsync(model);
            return (result > 0) ? (IActionResult)this.CreatedAtAction("Post", result) : (IActionResult)this.BadRequest();
        }

        // PUT api/<AutorController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(AutorDTO), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(int id, AutorDTO model)
        {
            if (model == null)
            {
                return (IActionResult)this.BadRequest();
            }

            AutorDTO result = await this.service.UpdateAutorAsync(model);
            return (result != null) ? (IActionResult)this.Ok(result) : (IActionResult)this.BadRequest();
        }

        // DELETE api/<AutorController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Delete(int id)
        {
            bool result = await this.service.DeleteAutorAsync(id);
            return (result) ? (IActionResult)this.Ok(result) : (IActionResult)this.BadRequest();
        }
    }
}
