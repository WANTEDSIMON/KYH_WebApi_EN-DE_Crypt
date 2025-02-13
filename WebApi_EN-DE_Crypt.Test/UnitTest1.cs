using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Primitives;
using Moq;
using Password;
using Xunit;
using Key;
using System.Net.Http;
using System.Net;

namespace WebApi_EN_DE_Crypt.Test
{
    public class UnitTest1
    {

// 🔹 Unit Tests for PasswordGenerator.cs
public class PasswordGeneratorTests
{
    [Fact]
    public void GenerateSecurePassword_ShouldReturnPasswordOfSpecifiedLength()
    {
        // Arrange
        int length = 16;

        // Act
        string password = PasswordGenerator.GenerateSecurePassword(length);

        // Assert
        Assert.NotNull(password);
        Assert.Equal(length, password.Length);
    }

    [Fact]
    public void GenerateSecurePassword_ShouldContainValidCharacters()
    {
        // Arrange
        int length = 16;
        const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_+-=[]{}|;:,.<>?";

        // Act
        string password = PasswordGenerator.GenerateSecurePassword(length);

        // Assert
        Assert.All(password, c => Assert.Contains(c, validChars));
    }

    [Fact]
    public void GetPasswordLength_ShouldReturnDefaultLength_WhenNoQueryParameter()
    {
        // Arrange
        var context = new DefaultHttpContext();

        // Act
        int length = PasswordGenerator.GetPasswordLength(context);

        // Assert
        Assert.Equal(12, length);
    }

    [Fact]
    public void GetPasswordLength_ShouldReturnCustomLength_WhenQueryParameterIsProvided()
    {
        // Arrange
        var context = new DefaultHttpContext();
        context.Request.Query = new QueryCollection(new Dictionary<string, StringValues>
        {
            { "length", "20" }
        });

        // Act
        int length = PasswordGenerator.GetPasswordLength(context);

        // Assert
        Assert.Equal(20, length);
    }

    [Fact]
    public void GetPasswordLength_ShouldReturnDefaultLength_WhenQueryParameterIsInvalid()
    {
        // Arrange
        var context = new DefaultHttpContext();
        context.Request.Query = new QueryCollection(new Dictionary<string, StringValues>
        {
            { "length", "invalid" }
        });

        // Act
        int length = PasswordGenerator.GetPasswordLength(context);

        // Assert
        Assert.Equal(12, length);
    }
}

// 🔹 Unit Tests for KeyGenerator.cs
public class KeyGeneratorTests
{
    [Fact]
    public void GenerateRandomKey_ShouldReturnKeyOfSpecifiedLength()
    {
        // Arrange
        const int expectedKeyLength = 32;

        // Act
        string key = KeyGenerator.GenerateRandomKey();
        byte[] keyBytes = Convert.FromBase64String(key);

        // Assert
        Assert.NotNull(key);
        Assert.Equal(expectedKeyLength, keyBytes.Length);
    }
}

// 🔹 Unit Tests for Program.cs
public class ProgramTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public ProgramTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GetRoot_ShouldReturnHelloEarth()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/");
        var content = await response.Content.ReadAsStringAsync();

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal("Hello Earth 🌎!", content);
    }

    [Fact]
    public async Task GetKey_ShouldReturnRandomKey()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/key");
        var content = await response.Content.ReadAsStringAsync();

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.NotNull(content);
    }

    [Fact]
    public async Task GetPassword_ShouldReturnGeneratedPassword()
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync("/password");
        var content = await response.Content.ReadAsStringAsync();

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Contains("Generated Password:", content);
    }

    [Fact]
    public async Task Encode_ShouldReturnEncodedText()
    {
        // Arrange
        var client = _factory.CreateClient();
        var text = "HelloWorld";
        var key = "MyKey";

        // Act
        var response = await client.GetAsync($"/encode?text={text}&key={key}");
        var content = await response.Content.ReadAsStringAsync();

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Contains("Encoded:", content);
    }

    [Fact]
    public async Task Decode_ShouldReturnDecodedText()
    {
        // Arrange
        var client = _factory.CreateClient();
        var text = "U2VjcmV0S2V5SGVsbG8gd29ybGQ=";
        var key = "SecretKey";

        // Act
        var response = await client.GetAsync($"/decode?text={text}&key={key}");
        var content = await response.Content.ReadAsStringAsync();

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Contains("Decoded:", content);
    }
}

    }
}
