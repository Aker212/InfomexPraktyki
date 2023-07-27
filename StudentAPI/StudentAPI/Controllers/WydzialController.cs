using Application.Dto;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WydzialController : ControllerBase
    {
        private readonly IWydzialService _wydzialService;

        public WydzialController(IWydzialService wydzialService)
        {
            _wydzialService = wydzialService;
        }

        [SwaggerOperation(Summary = "Zobacz wszystkie wydziały")]
        [HttpGet]
        public IActionResult Get()
        {
            var wydzialy = _wydzialService.GetAllWydzialy();
            return Ok(wydzialy);
        }

        [SwaggerOperation(Summary = "Wyszukaj wydział po id")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var wydzial = _wydzialService.GetWydzialById(id);

            if (wydzial is null)
                return NotFound();

            return Ok(wydzial);
        }

        [SwaggerOperation(Summary = "Dodaj nowy wydział")]
        [HttpPost]
        public IActionResult Add(AddWydzialDto newWydzial)
        {
            var wydzial = _wydzialService.AddWydzial(newWydzial);
            return Created($"api/wydzial/{wydzial.IdWydzialu}", wydzial);
        }

        [SwaggerOperation(Summary = "Zaktualizuj informacje o wydziale")]
        [HttpPut]
        public IActionResult Update(UpdateWydzialDto updateWydzial)
        {
            _wydzialService.UpdateWydzial(updateWydzial);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Usuń wydział")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _wydzialService.DeleteWydzial(id);
            return NoContent();
        }
    }
}
