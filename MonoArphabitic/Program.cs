using System;

class MonoalphabeticCipher
{
    static string Encrypt(string message, string keyUpper, string keyLower)
    {
        string encrypted = "";

        foreach (char c in message)
        {
            if (char.IsUpper(c))
            {
                encrypted += keyUpper[c - 'A']; // Encrypt uppercase
            }

            else if (char.IsLower(c))
            {
                encrypted += keyLower[c - 'a']; // Encrypt lowercase
            }

            else
            {
                encrypted += c; // Preserve non-alphabetic characters
            }
        }

        return encrypted;
    }

    static string Decrypt(string message, string keyUpper, string keyLower)
    {
        string alphabetUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        string alphabetLower = alphabetUpper.ToLower();
        string decrypted = "";

        foreach (char c in message)
        {
            if (char.IsUpper(c))
            {
                decrypted += alphabetUpper[keyUpper.IndexOf(c)]; // Decrypt uppercase
            }

            else if (char.IsLower(c))
            {
                decrypted += alphabetLower[keyLower.IndexOf(c)]; // Decrypt lowercase
            }

            else
            {
                decrypted += c; // Preserve non-alphabetic characters
            }
        }

        return decrypted;
    }

    static void Main(string[] args)
    {
        string keyUpper = "QWERTYUIOPASDFGHJKLZXCVBNM"; // Key for uppercase
        string keyLower = keyUpper.ToLower();

        
        
        Console.Write("Enter Message: ");
        string message = Console.ReadLine();

        // Encrypt the message
        string encryptedMessage = Encrypt(message, keyUpper, keyLower);
        Console.WriteLine($"Encrypted Message: {encryptedMessage}");

        // Decrypt the message
        string decryptedMessage = Decrypt(encryptedMessage, keyUpper, keyLower);
        Console.WriteLine($"Decrypted Message: {decryptedMessage}");
    }
}