using MySql.Data.MySqlClient;
using System;

class Program {
    static void Main(string[] args) {
        var builder = WebApplication.CreateBuilder(args);

        string connectionString = "Server=localhost;Database=music2ear;User=api;Password=password123;";
        builder.Services.AddSingleton(new MySqlConnection(connectionString));

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        app.Run();
    }
}

