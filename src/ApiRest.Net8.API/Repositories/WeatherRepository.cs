using MySql.Data.MySqlClient;

namespace ApiRest.Net8.API.Repositories;

public class WeatherRepository
{
    private readonly string _connectionString;

    public WeatherRepository(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("DefaultConnection");
    }

    public List<WeatherForecast> GetForecasts()
    {
        var forecasts = new List<WeatherForecast>();

        using var connection = new MySqlConnection(_connectionString);
        connection.Open();

        var cmd = new MySqlCommand("SELECT Date, TemperatureC, Summary FROM WeatherForecast", connection);

        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            forecasts.Add(new WeatherForecast
            {
                Date = DateOnly.FromDateTime(reader.GetDateTime("Date")),
                TemperatureC = reader.GetInt32("TemperatureC"),
                Summary = reader.GetString("Summary")
            });
        }

        return forecasts;
    }
}