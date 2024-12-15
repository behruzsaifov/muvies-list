using System.ComponentModel.DataAnnotations;

namespace Movies.Contracts.Responses;

public class MovieRatingResponse
{
    [Required]
    public Guid MovieId { get; init; }
    
    [Required]
    public string Slug { get; init; }
    
    [Required]
    public int Rating { get; init; }
}