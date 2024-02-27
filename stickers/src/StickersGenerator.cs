using System.Drawing;
using System.Drawing.Imaging;

namespace stickers;

#pragma warning disable CA1416
public class StickersGenerator
{
    private readonly HttpClient _client;

    public StickersGenerator()
    {
        _client = new();
    }
    public async void CreateSticker(string urlImage, string text, string nameSticker)
    {
        Bitmap originalImage = await GetImage(urlImage);

        int widthImage = originalImage.Width;
        int heightImage = originalImage.Height;

        int spaceForText;

        if (heightImage > widthImage) spaceForText = heightImage / 5;
        else spaceForText = heightImage / 4;

        int newHeightImage = heightImage + spaceForText;

        Bitmap newImage = new(widthImage, newHeightImage);
        newImage.MakeTransparent();

        Graphics sticker = Graphics.FromImage(newImage);
        Rectangle rectangle = new(0, 0, widthImage, heightImage);
        sticker.DrawImage(originalImage, rectangle);

        float x = widthImage / 2f;
        float y = newHeightImage - spaceForText / 2.5f;

        float fontSize;
        if (text.Length <= 5) fontSize = spaceForText * .8f;
        else if (text.Length > 5 && text.Length <= 9) fontSize = widthImage / (text.Length - 1);
        else fontSize = widthImage / (text.Length - 3);

        Font fontBorder = new("Impact", fontSize, FontStyle.Bold);
        Font fontConfig = new("Impact", fontSize - 2.5f, FontStyle.Bold);

        Brush brushBorder = new SolidBrush(Color.Gold);
        Brush brush = new SolidBrush(Color.Black);

        StringFormat textAlign = new()
        {
            LineAlignment = StringAlignment.Center,
            Alignment = StringAlignment.Center
        };

        sticker.DrawString(text, fontBorder, brushBorder, x, y, textAlign);
        sticker.DrawString(text, fontConfig, brush, x, y, textAlign);

        SaveSticker(nameSticker, newImage);

        sticker.Dispose();
    }

    private async Task<Bitmap> GetImage(string urlImagem)
    {
        if (!(urlImagem.EndsWith(".jpg") 
            || urlImagem.EndsWith(".jpeg") 
            || urlImagem.EndsWith(".png") 
            || urlImagem.EndsWith(".gif") 
            || urlImagem.EndsWith(".tiff") 
            || urlImagem.EndsWith(".bmp")  
            || urlImagem.EndsWith(".exif")))
        {
            throw new ImageExtensionsException("Ops.. Algo deu errado. Verifique o endereço da imagem.");
        }

        var response = _client.GetAsync(urlImagem).Result;
        using var stream = await response.Content.ReadAsStreamAsync();
        using var memStream = new MemoryStream();
        await stream.CopyToAsync(memStream);
        memStream.Position = 0;
        Bitmap originalImage = new(memStream);

        memStream.Dispose();
        return originalImage;
    }

    private static void SaveSticker(string nameSticker, Bitmap sticker)
    {
        string directoryPath = "./img/";

        if (!Directory.Exists(directoryPath)) Directory.CreateDirectory(directoryPath);

        string pathToSave = directoryPath + nameSticker + ".png";

        sticker.Save(pathToSave, ImageFormat.Png);
    }
}
#pragma warning restore CA1416
