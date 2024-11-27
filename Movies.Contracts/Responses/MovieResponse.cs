using System.ComponentModel.DataAnnotations;

namespace Movies.Contracts.Responses;

public class MovieResponse
{
    [Required]
    public Guid Id { get; init; }
    
    [Required]
    public string Title { get; init; }
    
    [Required]
    public string Slug { get; init; } 
    
    [Required]
    public int YearOfRelease { get; init; }

    [Required] public IEnumerable<string> Genres { get; init; } = Enumerable.Empty<string>();
}