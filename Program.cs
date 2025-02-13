using System;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using Key;
using Password;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "Hello Earth 🌎!");

        app.MapGet("/key", () => KeyGenerator.GenerateRandomKey());

        app.MapGet("/password", (HttpContext context) =>
        {
            int length = PasswordGenerator.GetPasswordLength(context);
            return Results.Text($"Generated Password: {PasswordGenerator.GenerateSecurePassword(length)}");
        });

        app.MapGet("/encode", (HttpContext context) =>
        {
            if (!context.Request.Query.TryGetValue("text", out StringValues text) || text.Count == 0 ||
                !context.Request.Query.TryGetValue("key", out StringValues key) || key.Count == 0)
            {
                return Results.BadRequest("Error: Missing 'text' or 'key' parameter. Example: /encode?text=HelloWorld&key=MyKey");
            }

            string encodedText = Convert.ToBase64String(Encoding.UTF8.GetBytes(key.ToString() + text.ToString()));
            return Results.Text($"Encoded: {encodedText}");
        });

        app.MapGet("/decode", (HttpContext context) =>
        {
            if (!context.Request.Query.TryGetValue("text", out StringValues encodedText) || encodedText.Count == 0 ||
                !context.Request.Query.TryGetValue("key", out StringValues key) || key.Count == 0)
            {
                return Results.BadRequest("Error: Missing 'text' or 'key' parameter. Example: /decode?text=U2VjcmV0S2V5SGVsbG8gd29ybGQ=&key=SecretKey");
            }

            try
            {
                byte[] decodedBytes = Convert.FromBase64String(encodedText.ToString());
                string decodedText = Encoding.UTF8.GetString(decodedBytes);

                if (decodedText.StartsWith(key.ToString()))
                {
                    return Results.Text($"Decoded: {decodedText.Substring(key.ToString().Length)}");
                }

                return Results.BadRequest("Error: Key does not match.");
            }
            catch (FormatException)
            {
                return Results.BadRequest("Error: Invalid Base64 string.");
            }
        });

        app.Run();
    }
}