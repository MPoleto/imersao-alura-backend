namespace stickers;

public interface IExtratorDeConteudo
{
  List<Conteudo> ExtraiConteudos(string json);
}
