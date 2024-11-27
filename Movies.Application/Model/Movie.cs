using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Movies.Application.Model;

public partial class Movie
{
    [Required] public Guid Id { get; init; }

    [Required] public string Title { get; set; }

    public string Slug => GenerateSlug();

    [Required] public int YearOfRelease { get; set; }

    [Required] public List<string> Genres { get; init; } = new();

    private string GenerateSlug()
    {
        var sluggedTitle = SlugRegex().Replace(Title, string.Empty)
            .ToLower()
            .Replace(" ", "-");
        return $"{sluggedTitle}-{YearOfRelease}";
    }

    [GeneratedRegex("[^0-9A-Za-z _-]", RegexOptions.NonBacktracking, 10)]
    private static partial Regex SlugRegex();

}
