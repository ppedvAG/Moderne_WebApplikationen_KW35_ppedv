namespace WebAPISample.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public GenreType GenreType { get; set; }
    }

    public enum GenreType { Action, Comedy, Drama, Horror, Thriller, Animation, Romance, History, ScienceFiction, Documentation}
}
