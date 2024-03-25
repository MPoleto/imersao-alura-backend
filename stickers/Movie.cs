using System.Text.Json.Serialization;

namespace stickers;

    public class MoviesList
    {
        [property:JsonPropertyName("items")]
        public List<Movie>? Movie { get; set; }
    }
    
    public class Movie
    {
        [property:JsonPropertyName("id")]
        public string? Id { get; set; }

        
        [property:JsonPropertyName("rank")]
        public string? Rank { get; set; }

        
        [property:JsonPropertyName("title")]
        public string? Title { get; set; }


        [property:JsonPropertyName("year")]
        public string? Year { get; set; }


        [property:JsonPropertyName("image")]
        public string? Image { get; set; }


        [property:JsonPropertyName("imDbRating")]
        public string? Rating { get; set; }

        public int PersonalRating { get; set; }
        
    }
