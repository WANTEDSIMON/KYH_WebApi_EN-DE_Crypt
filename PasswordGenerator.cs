using System.Security.Cryptography;

namespace Password
{
public static class PasswordGenerator
{
    private const int DefaultPasswordLength = 12; // Default password length

    public static string GenerateSecurePassword(int length)
    {
        const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()_+-=[]{}|;:,.<>?";
        char[] password = new char[length];

        using var rng = RandomNumberGenerator.Create();
        byte[] randomBytes = new byte[length];
        rng.GetBytes(randomBytes);

        for (int i = 0; i < length; i++)
        {
            password[i] = chars[randomBytes[i] % chars.Length];
        }

        return new string(password);
    }

    public static int GetPasswordLength(HttpContext context)
    {
        int length = DefaultPasswordLength;
        if (context.Request.Query.TryGetValue("length", out var lengthValue) && int.TryParse(lengthValue, out int customLength))
        {
            length = customLength;
        }
        return length;
    }
}
}