using System;
using System.Text;
/* Might need to uncomment
  using Microsoft.AspNetCore.Builder;
  using Microsoft.AspNetCore.Http;
  using Microsoft.Extensions.DependencyInjection; */
using Microsoft.Extensions.Primitives;
using Key;
using Password;

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


app.Run();
