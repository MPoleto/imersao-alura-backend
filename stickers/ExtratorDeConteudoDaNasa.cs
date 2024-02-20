namespace stickers;

public class ExtratorDeConteudoDaNasa : IExtratorDeConteudo
{
    public List<Conteudo> ExtraiConteudos(string json)
    {
      // Extrair dados de interesse: titulo, poster, classificação
      JsonParser parser = new();
      List<Dictionary<string, string>> listaDeAtributos = parser.ParseJson(json);

      List<Conteudo> conteudos = new();

      foreach (Dictionary<string, string> atributos in listaDeAtributos)
      {
        string titulo = atributos.GetValueOrDefault("title").Replace(": ", "-").Replace(",", "");
        string urlImagem = atributos.GetValueOrDefault("url");

        var conteudo = new Conteudo(titulo, urlImagem);
        
        conteudos.Add(conteudo);
      }

      return conteudos;
    }
}
