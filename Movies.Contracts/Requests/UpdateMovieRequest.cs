using System.ComponentModel.DataAnnotations;

namespace Movies.Contracts.Requests;

public class UpdateMovieRequest
{
    [Required]
    public string Title { get; init; }
    
    [Required]
    public int YearOfRelease { get; init; }

    [Required] public IEnumerable<string> Genres { get; init; } = Enumerable.Empty<string>();
}