using Dapper;

namespace Movies.Application.Database;

public class DbInitializer
{
    private readonly IDbConnectionFactory _dbConnectionFactory;

    public DbInitializer(IDbConnectionFactory dbConnectionFactory)
    {
        _dbConnectionFactory = dbConnectionFactory;
    }

    public async Task InitializerAsync()
    {
        using var connection = await _dbConnectionFactory.CreateConnectionAsync();
        await connection.ExecuteAsync("""
                                          CREATE TABLE IF NOT EXISTS movies (
                                              id UUID PRIMARY KEY,
                                              slug TEXT NOT NULL,
                                              title TEXT NOT NULL,
                                              yearofrelease INTEGER NOT NULL
                                          );
                                      """);

        await connection.ExecuteAsync("""
                                          create unique index concurrently if not exists movies_slug_idx
                                          on movies
                                          using btree(slug);
                                      """);

        await connection.ExecuteAsync("""
                                          create table if not exists genres (
                                              movieId UUID references movies(Id),
                                              name TEXT not null
                                          );
                                      """);
    }
}