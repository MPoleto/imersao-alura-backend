using System.Drawing;
using System.Net;

namespace stickers;

    #pragma warning disable CA1416 // Validate platform compatibility
    public class GeradoraDeFigurinhas
    {
        public void Criar(string url, string nomeSticker)
        {
            // LEITURA DA IMAGEM
            // string path = "./img/TopMovies_1.jpg";
            // Bitmap imagemOriginal = new(path);

            // ENDEREÇO IMAGEM
            // string url = "https://cdn.myshoptet.com/usr/www.zuty.cz/user/shop/big/14231-1_malovani-podle-cisel-pulp-fiction.png";
            
            //ABRIR IMAGEM DA INTERNET COM WEBREQUEST
            WebRequest request = WebRequest.Create(url);
            WebResponse response = request.GetResponse();
            Stream streamImg = response.GetResponseStream();
            Bitmap imagemOriginal = new(streamImg);

            // criar nova imagem em memória com transparencia e com tamanho novo
            int largura = imagemOriginal.Width;
            int altura = imagemOriginal.Height;
            int novaAltura = altura + altura/5;

            Bitmap novaImagem = new(largura, novaAltura);
            novaImagem.MakeTransparent();

            // copiar a imagem original para nova imagem (em memória)
            Graphics sticker = Graphics.FromImage(novaImagem);
            Rectangle rectangle = new(0, 0, largura, altura);
            sticker.DrawImage(imagemOriginal, rectangle);

            // escrever uma frase na nova imagem
            string text = "TOPZERA";

            float x = 0;
            float y = novaAltura - 50;

            Font fontConfig = new(FontFamily.GenericSansSerif, 34, FontStyle.Bold);

            Brush brush = new SolidBrush(Color.Yellow);

            sticker.DrawString(text, fontConfig, brush, x, y);

            // escrever a nova imagem em um arquivo
            novaImagem.Save(nomeSticker, System.Drawing.Imaging.ImageFormat.Png);
        }
    }
    #pragma warning restore CA1416 // Validate platform compatibility
