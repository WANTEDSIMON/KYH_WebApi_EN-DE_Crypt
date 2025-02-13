using System;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Primitives;

// Ensure these classes exist in your project
using Key;  // Import the namespace containing KeyGenerator
using Password;  // Import the namespace containing PasswordGenerator

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Hello Earth 🌎!");

        // Route for generating a random key
        app.MapGet("/key", () => KeyGenerator.GenerateRandomKey());

        // Route for generating a secure password
        app.MapGet("/password", (HttpContext context) =>
        {
            try
            {
                int length = PasswordGenerator.GetPasswordLength(context);
                return Results.Text($"Generated Password: {PasswordGenerator.GenerateSecurePassword(length)}");
            }
            catch (Exception ex)
            {
                return Results.BadRequest($"Error generating password: {ex.Message}");
            }
        });

        // Route for encoding text with a key
        app.MapGet("/encode", (HttpContext context) =>
        {
            if (!context.Request.Query.TryGetValue("text", out StringValues text) || text.Count == 0 ||
                !context.Request.Query.TryGetValue("key", out StringValues key) || key.Count == 0)
            {
                return Results.BadRequest("Missing 'text' or 'key' parameter. Example: /encode?text=HelloWorld&key=MyKey");
            }

            try
            {
                string encodedText = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{key}{text}"));
                return Results.Text($"Encoded: {encodedText}");
            }
            catch (Exception ex)
            {
                return Results.BadRequest($"Encoding error: {ex.Message}");
            }
        });

        // Route for decoding text with a key
        app.MapGet("/decode", (HttpContext context) =>
        {
            if (!context.Request.Query.TryGetValue("text", out StringValues encodedText) || encodedText.Count == 0 ||
                !context.Request.Query.TryGetValue("key", out StringValues key) || key.Count == 0)
            {
                return Results.BadRequest("Missing 'text' or 'key' parameter. Example: /decode?text=U2VjcmV0S2V5SGVsbG8gd29ybGQ=&key=SecretKey");
            }

            try
            {
                byte[] decodedBytes = Convert.FromBase64String(encodedText.ToString());
                string decodedText = Encoding.UTF8.GetString(decodedBytes);

                if (decodedText.StartsWith(key.ToString()))
                {
                    return Results.Text($"Decoded: {decodedText.Substring(key.ToString().Length)}");
                }

                return Results.BadRequest("Error: Incorrect key or invalid encoded string.");
            }
            catch (FormatException)
            {
                return Results.BadRequest("Invalid Base64 string format. Ensure it was encoded correctly.");
            }
        });

        app.Run();
    }
}
