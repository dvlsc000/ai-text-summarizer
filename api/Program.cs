using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace ApiProject
{
    // Request and Response DTOs -> data going in 
    public class SummarizeRequest
    {
        public string Text { get; set; } = string.Empty;
    }

    public class SummarizeResponse
    {
        public string Summary { get; set; } = string.Empty;
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            /* Create a buider object that:
                -> Loads configuration
                -> Sets up logging
                -> Prepares dependency injection
            */
            var builder = WebApplication.CreateBuilder(args);

            // CORS -> to controll API calls from the browser
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost", policy =>
                {
                    policy
                        .AllowAnyHeader() // Accept any HTTP header
                        .AllowAnyMethod() // Accept any HTTP method (GET, POST, etc.)
                        .WithOrigins("http://localhost:5173", "http://localhost:3000");
                });
            });

            // Build the app
            var app = builder.Build();

            /* Middleware pipeline configuratione
                -> HTTPS redirection
                -> CORS enabling
            */
            app.UseHttpsRedirection();
            app.UseCors("AllowLocalhost");

            // Root endpoint health check
            app.MapGet("/", () => "AI Summarizer API is running!");

           
        }
    }
}
