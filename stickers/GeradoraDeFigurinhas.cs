using System.Drawing;
using System.Net;

namespace stickers;

#pragma warning disable CA1416 // Validate platform compatibility
public class GeradoraDeFigurinhas
{
    public void CreateSticker(string url, string text, string nameSticker)
    {
        // LEITURA DA IMAGEM
        // string path = "./img/TopMovies_1.jpg";
        // Bitmap originalImage = new(path);

        // ENDEREÇO IMAGEM
        // string url = @"https://cdn.myshoptet.com/usr/www.zuty.cz/user/shop/big/14231-1_malovani-podle-cisel-pulp-fiction.png";

        //ABRIR IMAGEM DA INTERNET COM WEBREQUEST
        WebRequest request = WebRequest.Create(url);
        WebResponse response = request.GetResponse();
        Stream streamImage = response.GetResponseStream();
        Bitmap originalImage = new(streamImage);

        // criar nova imagem em memória com transparencia e com tamanho novo
        int widthImage = originalImage.Width;
        int height = originalImage.Height;

        int spaceForText = height / 5;
        int newHeight = height + spaceForText;

        Bitmap newImage = new(widthImage, newHeight);
        newImage.MakeTransparent();

        // copiar a imagem original para nova imagem (em memória)
        Graphics sticker = Graphics.FromImage(newImage);
        Rectangle rectangle = new(0, 0, widthImage, height);
        sticker.DrawImage(originalImage, rectangle);

        // escrever uma frase na nova imagem
        float x = widthImage / 2f;
        float y = newHeight - spaceForText / 2.5f;

        float fontSize;
        if (text.Length <= 5) fontSize = spaceForText * .83f;
        else if (text.Length > 5 && text.Length <= 7) fontSize = widthImage / (text.Length - 2);
        else fontSize = widthImage / (text.Length - 3.5f);

        Font fontBorder = new("Impact", fontSize, FontStyle.Bold);
        Font fontConfig = new("Impact", fontSize - 2.5f, FontStyle.Bold);

        Brush brushBorder = new SolidBrush(Color.GreenYellow);
        Brush brush = new SolidBrush(Color.Black);

        StringFormat textAlign = new()
        {
            LineAlignment = StringAlignment.Center,
            Alignment = StringAlignment.Center
        };

        sticker.DrawString(text, fontBorder, brushBorder, x, y, textAlign);
        sticker.DrawString(text, fontConfig, brush, x, y, textAlign);

        // escrever a nova imagem em um arquivo
        string directoryPath = "./img/";

        if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);

        string pathToSave = directoryPath + nameSticker + ".png";

        newImage.Save(pathToSave, System.Drawing.Imaging.ImageFormat.Png);

        sticker.Dispose();
        streamImage.Dispose();
    }
}
#pragma warning restore CA1416 // Validate platform compatibility
