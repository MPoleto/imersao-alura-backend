namespace stickers;

public class ExtratorDeConteudoDoIMDB : IExtratorDeConteudo
{
  public List<Conteudo> ExtraiConteudos(string json)
  {
    // Extrair dados de interesse: titulo, poster, classificação
    JsonParser parser = new();
    List<Dictionary<string, string>> listaDeAtributos = parser.ParseJson(json);

    List<Conteudo> conteudos = new();

    for (var i = 0; i < 6; i++)
    //foreach (Dictionary<string, string> atributos in listaDeAtributos)
    {
      string titulo = listaDeAtributos[i].GetValueOrDefault("title").Replace(": ", "-").Replace(",", "");
      string urlImagem = listaDeAtributos[i].GetValueOrDefault("image");

      string newUrlImagem = RemoveLimitationOfImageSize(urlImagem);

      var conteudo = new Conteudo(titulo, newUrlImagem);

      conteudos.Add(conteudo);
    }

    return conteudos;
  }

  private string RemoveLimitationOfImageSize(string url)
  {
    // Tratar imagem para pegá-las em tamanho maior
    string arroba = "@";
    string pontoDaExtensao = ".";

    int start = url.IndexOf(arroba + 1);
    int end = url.LastIndexOf(pontoDaExtensao);

    if (start == -1)
    {
      start = url.LastIndexOf("._");
    }
    int diference = end - start;

    return url.Remove(start, diference);
  }

  private string AddTextByRating(int index, double rating)
  {
    string text = "";

    if (index < 10 && rating >= 9) text = "TOPZERA";
    else if (index < 10 && rating < 9 && rating >= 8.8) text = "TOP";
    else if (index >= 10 && index < 100 && rating >= 8.5) text = "COOL";
    else text = "OK";

    return text;
  }
}
