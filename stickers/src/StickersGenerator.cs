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

        int spaceForText = CalculateWordSpace(widthImage, heightImage);

        int newHeightImage = heightImage + spaceForText;

        Bitmap newImage = new(widthImage, newHeightImage);
        newImage.MakeTransparent();

        Graphics sticker = Graphics.FromImage(newImage);
        Rectangle rectangle = new(0, 0, widthImage, heightImage);
        sticker.DrawImage(originalImage, rectangle);

        AddTextToSticker(sticker, text, spaceForText, widthImage, newHeightImage);

        SaveSticker(nameSticker, newImage);

        sticker.Dispose();
    }

    private async Task<Bitmap> GetImage(string urlImage)
    {
        if (!IsTheImageExtensionCorrect(urlImage))
        {
            throw new ImageExtensionsException("Ops.. Algo deu errado. Verifique o endereço da imagem.");
        }

        var response = _client.GetAsync(urlImage).Result;
        using var stream = await response.Content.ReadAsStreamAsync();
        using var memStream = new MemoryStream();
        await stream.CopyToAsync(memStream);
        memStream.Position = 0;
        Bitmap originalImage = new(memStream);

        memStream.Dispose();
        return originalImage;
    }

    private static bool IsTheImageExtensionCorrect(string urlImage)
    {
        var extensions = new List<string>() {".jpg", ".jpeg", ".png", ".gif", ".tiff", ".bmp", ".exif"};
        var imgExtension = Path.GetExtension(urlImage);

        foreach (var extension in extensions)
        {
            if (extension.Equals(imgExtension)) return true;
        }
        return false;
    }

    private static int CalculateWordSpace(int widthImage, int heightImage)
    {
        if (heightImage > widthImage) return heightImage / 5;
        else return heightImage / 4;
    }

    private static void AddTextToSticker(Graphics sticker, string text, int wordSpace, int widthImage, int heightImage)
    {
        float x = widthImage / 2f;
        float y = heightImage - wordSpace / 2.5f;

        float fontSize;
        if (text.Length <= 5) fontSize = wordSpace * .8f;
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
