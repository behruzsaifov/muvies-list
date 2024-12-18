using System.ComponentModel.DataAnnotations;

namespace Movies.Contracts.Responses;

public class PageResponse<TResponse>
{
    [Required] public IEnumerable<TResponse> Items { get; set; } = Enumerable.Empty<TResponse>();
    
    [Required] 
    public int PageSize { get; init; }
    
    [Required] 
    public int Page { get; init; }
    
    [Required]
    public int Total { get; init; }
    
    public bool HasNextPage => Total > (Page * PageSize );
}