using System.Text.RegularExpressions;

namespace stickers;

public class JsonParser
{
    private static readonly Regex _regexItens = new(".*\\[(.+)\\].*", RegexOptions.Compiled);
    private static readonly Regex _regexAttributesJson = new("\"(.+?)\":\"(.*?)\"", RegexOptions.Compiled);
    
    public List<Dictionary<string, string>> ParseJson (string json)
    {
        Match match = _regexItens.Match(json);

        if (!match.Success)
        {
            throw new ArgumentException("Não encontrou items.");
        }
            
        string[] items = match.Groups[1].ToString().Split("},{");

        List<Dictionary<string, string>> data = new();

        foreach (var item in items)
        {
            Dictionary<string, string> attributesItem = new();

            Match matchAttributes = _regexAttributesJson.Match(item);

            while (matchAttributes.Success)
            {
                string attribute = matchAttributes.Groups[1].ToString();
                string value = matchAttributes.Groups[2].ToString();
                attributesItem.Add(attribute, value);

                matchAttributes = matchAttributes.NextMatch();
            }

            data.Add(attributesItem);
        }

        return data;
    }
}
