using System;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Choose :");
            Console.WriteLine("1. Encrypt a message");
            Console.WriteLine("2. Decrypt a message");
            Console.WriteLine("3. Quit");

            int choice = GetUserChoice(1, 3);

            if (choice == 3) break;

            Console.WriteLine("\nEnter the message :");
            string message = Console.ReadLine();

            int key = GetKey();

            if (choice == 1)
            {
                string encryptedMessage = EncryptMessage(message, key);
                Console.WriteLine($"\nEncrypted Message: {encryptedMessage}");
            }
            else if (choice == 2)
            {
                string decryptedMessage = DecryptMessage(message, key);
                Console.WriteLine($"\nDecrypted Message: {decryptedMessage}");
            }

            Console.WriteLine("\nPress any key to return to the main menu...");
            Console.ReadKey();
        }
    }

    
    static int GetUserChoice(int min, int max)
    {
        int choice;
        while (true)
        {
            Console.Write("Enter your choice (1, 2, or 3): ");
            if (int.TryParse(Console.ReadLine(), out choice) && choice >= min && choice <= max)
                break;
            Console.WriteLine("Invalid input. Please enter 1, 2, or 3.");
        }
        return choice;
    }


    static int GetKey()
    {
        int key;
        while (true)
        {
            Console.Write("\nEnter the key (1-25): ");
            if (int.TryParse(Console.ReadLine(), out key) && key >= 1 && key <= 25)
                break;
            Console.WriteLine("Invalid key. Please enter a number between 1 and 25.");
        }
        return key;
    }

  
    static string EncryptMessage(string message, int key)
    {
        char[] encryptedMessage = new char[message.Length];

        for (int i = 0; i < message.Length; i++)
        {
            char c = message[i];
            encryptedMessage[i] = ShiftCharacter(c, key);
        }

        return new string(encryptedMessage);
    }

    static string DecryptMessage(string message, int key)
    {
        char[] decryptedMessage = new char[message.Length];

        for (int i = 0; i < message.Length; i++)
        {
            char c = message[i];
            decryptedMessage[i] = ShiftCharacter(c, -key);
        }

        return new string(decryptedMessage);
    }

    static char ShiftCharacter(char c, int key)
    {
        if (char.IsLetter(c))
        {
            char offset = char.IsUpper(c) ? 'A' : 'a';
            int newChar = ((c - offset + key + 26) % 26) + offset;
            return (char)newChar;
        }

        return c;
    }
}
