using Microsoft.AspNetCore.Mvc;

namespace languages_api;

[ApiController]
[Route("[controller]")]
public class LanguageController : ControllerBase
{
    private readonly LanguageService _service;

    public LanguageController(LanguageService service)
    {
      _service = service;
    }

    [HttpGet]
    public List<Language> Get()
    {
      List<Language> linguagens = _service.FindAll();
      return linguagens;
    }

    [HttpGet("ranking")]
    public List<Language> GetByRanking()
    {
      List<Language> linguagens = _service.SortByRank();

      return linguagens;
    }

    [HttpGet("name")]
    public IActionResult GetByName([FromQuery] string languageName)
    {
      var language = _service.FindByName(languageName);

      if(language is null)
        return NotFound();

      return Ok(language);
    }

    [HttpPost]
    public IActionResult CadastrarLinguagens([FromBody] Language newLanguage)
    {
      _service.Create(newLanguage);

      return CreatedAtAction(nameof(Get), new { id = newLanguage.Id }, newLanguage);
    }

    [HttpPut("{id:length(24)}")]
    public IActionResult Update(string id, [FromBody] Language updatedLanguage)
    {
      var language = _service.FindById(id);

      if(language is null)
        return NotFound();
      
      updatedLanguage.Id = language.Id;

      _service.Update(id, updatedLanguage);

      return NoContent();
    }

    [HttpPatch("favorite/{languageName}")]
    public IActionResult FavoriteLanguage(string languageName)
    {
      _service.UpdateAccessCount(languageName);
      return Ok("Voto contabilizado e ranking atualizado");
    }

    [HttpDelete("{id:length(24)}")]
    public IActionResult Delete(string id)
    {
      var language = _service.FindById(id);

      if(language is null)
        return NotFound();

      _service.Remove(id);

      return NoContent();
    }
}
