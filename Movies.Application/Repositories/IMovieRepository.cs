using Movies.Application.Model;

namespace Movies.Application.Repositories;

public interface IMovieRepository
{
    Task<bool> CreateAsync(Movie movie, CancellationToken token = default);
    Task<Movie?> GetByIdAsync(Guid id, Guid? userid = default, CancellationToken token = default);
    Task<Movie?> GetBySlugAsync(string slug, Guid? userid = default, CancellationToken token = default);
    Task<IEnumerable<Movie>> GetAllAsync(Guid? userid = default, CancellationToken token = default);
    Task<bool> UpdateAsync(Movie movie, Guid? userid = default, CancellationToken token = default);
    Task<bool> DeleteByIdAsync(Guid id, CancellationToken token = default);
    Task<bool> ExistsByIdAsync(Guid id, CancellationToken token = default);

}