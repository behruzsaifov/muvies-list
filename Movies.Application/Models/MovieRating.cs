using System.ComponentModel.DataAnnotations;

namespace Movies.Application.Models;

public class MovieRating
{
    [Required]
    public Guid MovieId { get; init; }
    
    [Required]
    public string Slug { get; init; }
    
    [Required]
    public int Rating { get; init; }
}