using System.Text.Json;
using Microsoft.Extensions.DependencyInjection;
using Movies.Api.Sdk;
using Movies.Api.Sdk.Consumer;
using Movies.Contracts.Requests;
using Refit;

// var moviesApi = RestService.For<IMoviesApi>("https://localhost:7163");

var services = new ServiceCollection();

services
    .AddHttpClient()
    .AddSingleton<AuthTokenProvider>()
    .AddRefitClient<IMoviesApi>(s => new RefitSettings
    {
        AuthorizationHeaderValueGetter = async () => await s.GetRequiredService<AuthTokenProvider>().GetTokenAsync()
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