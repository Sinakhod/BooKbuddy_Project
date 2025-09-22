using System;
using System.Security.Cryptography;
using System.Text;

public static class PasswordHelper
{
    // Generate a SHA256 hash with a salt
    public static string HashPassword(string password, string salt = null)
    {
        if (salt == null)
        {
            // Generate a random 16-byte salt
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            salt = Convert.ToBase64String(saltBytes);
        }

        // Combine password + salt
        string saltedPassword = password + salt;

        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
            string hash = Convert.ToBase64String(hashBytes);
            // Store hash and salt together, separated by a colon
            return $"{hash}:{salt}";
        }
    }

    // Verify a password against a stored hash
    public static bool VerifyPassword(string enteredPassword, string storedHash)
    {
        // storedHash format: "hash:salt"
        var parts = storedHash.Split(':');
        if (parts.Length != 2) return false;

        string hash = parts[0];
        string salt = parts[1];

        // Hash the entered password with the stored salt
        string enteredHash = HashPassword(enteredPassword, salt).Split(':')[0];

        return hash == enteredHash;
    }
}

