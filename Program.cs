using System;
using Key;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello Earth 🌎!");

app.MapGet("/key", () => KeyGenerator.GenerateRandomKey());

app.Run();
