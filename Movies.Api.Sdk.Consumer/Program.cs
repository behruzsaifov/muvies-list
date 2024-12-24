using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Movies.Api.Sdk;
using Movies.Contracts.Requests;
using Refit;

// var moviesApi = RestService.For<IMoviesApi>("https://localhost:7163");

var services = new ServiceCollection();

services.AddRefitClient<IMoviesApi>(x => new RefitSettings
    {
        AuthorizationHeaderValueGetter = () =>
            Task.FromResult("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJqdGkiOiIwMjljZjZlYi0zMDA4LTRiYjUtOGM3Mi00ZWQ1YzNkMzg4YmUiLCJzdWIiOiJuaWNrQG5pY2tjaGFwc2FzLmNvbSIsImVtYWlsIjoibmlja0BuaWNrY2hhcHNhcy5jb20iLCJ1c2VyaWQiOiJkODU2NmRlMy1iMWE2LTRhOWItYjg0Mi04ZTM4ODdhODJlNDEiLCJhZG1pbiI6dHJ1ZSwidHJ1c3RlZF9tZW1iZXIiOnRydWUsIm5iZiI6MTczNTA1OTI3MCwiZXhwIjoxNzM1MDg4MDcwLCJpYXQiOjE3MzUwNTkyNzAsImlzcyI6Imh0dHBzOi8vaWQubmlja2NoYXBzYXMuY29tIiwiYXVkIjoiaHR0cHM6Ly9tb3ZpZXMubmlja2NoYXBzYXMuY29tIn0.c3R7GmyhRdTMRVa_VjhsIIJHPC3sWCSFjWqW4MGJk_8")
    })
    .ConfigureHttpClient(client =>
    {
        client.BaseAddress = new Uri("https://localhost:7163");
    });

var provider = services.BuildServiceProvider();

var moviesApi = provider.GetRequiredService<IMoviesApi>();

var movie = await moviesApi.GetMovieAsync("nick-the-greek-2023");

var request = new GetAllMoviesRequest
{
    Title = null,
    Year = null,
    SortBy = null,
    Page = 1,
    PageSize = 3,
};

var movies = await moviesApi.GetAllMoviesAsync(request);

foreach (var movieResponse in movies.Items)
{
    Console.WriteLine(JsonSerializer.Serialize(movieResponse));
}