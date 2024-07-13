using Microsoft.AspNetCore.Mvc;

namespace languages_api;

[ApiController]
[Route("[controller]")]
public class LanguagesController : ControllerBase
{
    private readonly LanguageService _service;

    public LanguagesController(LanguageService service)
    {
        _service = service;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<List<Language>> Get()
    {
        List<Language> linguagens = _service.FindAll();
        
        return Ok(linguagens);
    }

    [HttpGet("Ranking")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public ActionResult<List<Language>> GetByRanking()
    {
        List<Language> linguagens = _service.SortByRank();

        return Ok(linguagens);
    }

    [HttpGet("Name")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult GetByName([FromQuery] string languageName)
    {
        var language = _service.FindByName(languageName);

        if(language is null)
          return NotFound();

        return Ok(language);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult CadastrarLinguagens([FromBody] Language newLanguage)
    {
        _service.Create(newLanguage);

        return CreatedAtAction(nameof(Get), new { id = newLanguage.Id }, newLanguage);
    }

    [HttpPut("{id:length(24)}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Update(string id, [FromBody] Language updatedLanguage)
    {
        var language = _service.FindById(id);

        if(language is null)
          return NotFound();
        
        updatedLanguage.Id = language.Id;

        _service.Update(id, updatedLanguage);

        return NoContent();
    }

    [HttpPatch("Favorite/{languageName}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult FavoriteLanguage(string languageName)
    {
        try
        {
            _service.UpdateAccessCount(languageName);
            return Ok("Voto contabilizado e ranking atualizado");
          
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    [HttpDelete("{id:length(24)}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public IActionResult Delete(string id)
    {
        var language = _service.FindById(id);

        if(language is null)
          return NotFound();

        _service.Remove(id);

        return NoContent();
    }
}
