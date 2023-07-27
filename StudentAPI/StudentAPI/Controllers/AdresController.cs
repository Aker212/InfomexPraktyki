using Application.Dto;
using Application.Services;
using Application.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdresController : ControllerBase
    {
        private readonly IAdresService _adresService;

        public AdresController(IAdresService adresService)
        {
            _adresService = adresService;
        }

        [SwaggerOperation(Summary = "Zobacz wszystkie adresy")]
        [HttpGet]
        public IActionResult Get()
        {
            var adres = _adresService.GetAllAdresy();
            return Ok(adres);
        }

        [SwaggerOperation(Summary = "Wyszukaj adres po id")]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var adres = _adresService.GetAdresById(id);

            if (adres is null)
                return NotFound();

            return Ok(adres);
        }

        [SwaggerOperation(Summary = "Dodaj nowy adres")]
        [HttpPost]
        public IActionResult Add(AddAdresDto newAdres)
        {
            var adres = _adresService.AddAdres(newAdres);
            return Created($"api/adres/{adres.IdAdresu}", adres);
        }

        [SwaggerOperation(Summary = "Zaktualizuj informacje o adresie")]
        [HttpPut]
        public IActionResult Update(UpdateAdresDto updateAdres)
        {
            _adresService.UpdateAdres(updateAdres);
            return NoContent();
        }

        [SwaggerOperation(Summary = "Usuń adres")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _adresService.DeleteAdres(id);
            return NoContent();
        }
    }
}
