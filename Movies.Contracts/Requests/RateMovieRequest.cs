using System.ComponentModel.DataAnnotations;

namespace Movies.Contracts.Requests;

public class RateMovieRequest
{
    [Required]
    public int Rating { get; init; }
}