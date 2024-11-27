using System.ComponentModel.DataAnnotations;

namespace Movies.Contracts.Responses;

public class MoviesResponse
{
    [Required] public IEnumerable<MovieResponse> Items { get; set; } = Enumerable.Empty<MovieResponse>();
}