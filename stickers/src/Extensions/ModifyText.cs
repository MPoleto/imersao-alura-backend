namespace stickers;

public static class ModifyText
{
    public static string AddTextByRating(int index, double rating)
    {
        string text;

        if (index < 10 && rating >= 9) text = "TOPZERA";
        else if (index < 10 && rating < 9 && rating >= 8.8) text = "TOP";
        else if (index >= 10 && index < 100 && rating >= 8.5) text = "COOL";
        else text = "OK";

        return text;
    }
}
