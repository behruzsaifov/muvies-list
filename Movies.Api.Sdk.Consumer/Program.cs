using System.Text.Json;
using Movies.Api.Sdk;
using Refit;

var moviesApi = RestService.For<IMoviesApi>("https://localhost:7163");

var movie = await moviesApi.GetMoviesAsync("nick-the-greek-2023");

Console.WriteLine(JsonSerializer.Serialize(movie));