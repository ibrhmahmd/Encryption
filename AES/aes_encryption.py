from cryptography.fernet import Fernet
import base64

def generate_key():
    return Fernet.generate_key()

def encrypt(message):
    key = generate_key()
    f = Fernet(key)
    encrypted_data = f.encrypt(message.encode())
    return {
        'key': base64.b64encode(key).decode('utf-8'),
        'encrypted': base64.b64encode(encrypted_data).decode('utf-8')
    }

def decrypt(encrypted_data, key):
    try:
        key = base64.b64decode(key)
        encrypted_data = base64.b64decode(encrypted_data)
        f = Fernet(key)
        decrypted_data = f.decrypt(encrypted_data)
        return decrypted_data.decode('utf-8')
    except Exception as e:
        return f"Decryption error: {str(e)}"

# Get user input
message = input('Enter a message: ')

# Encrypt the message
result = encrypt(message)
print(f'\nEncrypted message: {result["encrypted"]}')
print(f'Encryption key: {result["key"]}')

# Decrypt the message
decrypted = decrypt(result['encrypted'], result['key'])
print(f'\nDecrypted message: {decrypted}')