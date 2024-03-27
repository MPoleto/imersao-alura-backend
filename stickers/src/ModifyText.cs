namespace stickers;

public static class ModifyText
{
  public static string AddTextByRating(int index, double rating)
  {
    if (index < 10 && rating >= 9) return "TOPZERA";
    else if (index < 10 && rating < 9 && rating >= 8.8) return "TOP";
    else if (index >= 10 && index < 100 && rating >= 8.5) return "COOL";
    else return "OK";
  }
}
