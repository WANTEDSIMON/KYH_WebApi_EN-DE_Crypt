using System;
using Key;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello Earth 🌎!");

app.MapGet("/key", () => KeyGenerator.GenerateRandomKey());

app.MapGet("/password", (HttpContext context) =>
{
    int length = PasswordGenerator.GetPasswordLength(context);
    return Results.Text($"Generated Password: {PasswordGenerator.GenerateSecurePassword(length)}");
});

app.Run();
