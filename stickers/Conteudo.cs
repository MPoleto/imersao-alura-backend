using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stickers;

public class Conteudo
{
    private readonly string _titulo;
    private readonly string _urlImagem;

    public Conteudo(string titulo, string urlImagem)
    {
        _titulo = titulo;
        _urlImagem = urlImagem;
    }

    public string UrlImagem => _urlImagem;
    public string Titulo => _titulo;

}
