using Application.Dto;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KursController : ControllerBase
    {
        private readonly IKursService _kursService;

        public KursController(IKursService kursService)
        {
            _kursService = kursService;
        }

        [SwaggerOperation(Summary = "Zobacz wszystkie kursy")]
        [HttpGet]
        public IActionResult Get()
        {
            var kursy = _kursService.GetAllKursy();
            return Ok(kursy);
        }

        [SwaggerOperation(Summary = "Wyszukaj kurs po id")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var kurs = _kursService.GetKursById(id);

            if (kurs is null)
                return NotFound();

            return Ok(kurs);
        }

        [SwaggerOperation(Summary = "Dodaj nowy kurs")]
        [HttpPost]
        public IActionResult Add(AddKursDto newKurs)
        {
            var kurs = _kursService.AddKurs(newKurs);
            return Created($"api/kurs/{kurs.IdKursu}", kurs);
        }

        [SwaggerOperation(Summary = "Zaktualizuj informacje o kursie")]
        [HttpPut]
        public IActionResult Update(UpdateKursDto updateKurs)
        {
            _kursService.UpdateKurs(updateKurs);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Usuń kurs")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _kursService.DeleteKurs(id);
            return NoContent();
        }
    }
}
