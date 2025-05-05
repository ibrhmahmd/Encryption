import random
import math

def is_prime(n):
    if n < 2:
        return False
    for i in range(2, int(math.sqrt(n)) + 1):
        if n % i == 0:
            return False
    return True

def generate_prime(min_value=100, max_value=1000):
    prime = random.randint(min_value, max_value)
    while not is_prime(prime):
        prime = random.randint(min_value, max_value)
    return prime

def find_primitive_root(p):
    """Find a primitive root for prime p."""
    def factor(n):
        factors = set()
        for i in range(1, int(math.sqrt(n)) + 1):
            if n % i == 0:
                factors.add(i)
                factors.add(n // i)
        return sorted(factors)

    if not is_prime(p):
        raise ValueError("Number must be prime")
    
    phi = p - 1
    factors = factor(phi)
    
    for g in range(2, p):
        valid = True
        for factor in factors[1:-1]:  # Skip 1 and phi
            if pow(g, factor, p) == 1:
                valid = False
                break
        if valid:
            return g
    
    return None

class DiffieHellman:
    def __init__(self, prime=None, generator=None):
        # If prime and generator are not provided, generate them
        self.prime = prime if prime else generate_prime()
        self.generator = generator if generator else find_primitive_root(self.prime)
        
        # Generate private key
        self.private_key = random.randint(2, self.prime - 2)
        # Calculate public key
        self.public_key = pow(self.generator, self.private_key, self.prime)
    
    def generate_shared_secret(self, other_public_key):
        """Generate the shared secret using the other party's public key."""
        return pow(other_public_key, self.private_key, self.prime)

# Example usage
def main():
    # Initialize Alice and Bob with the same prime and generator
    prime = generate_prime()
    generator = find_primitive_root(prime)
    
    print(f"Using prime: {prime}")
    print(f"Using generator: {generator}\n")
    
    # Create instances for Alice and Bob
    alice = DiffieHellman(prime, generator)
    bob = DiffieHellman(prime, generator)
    
    print("Private Keys (should be kept secret):")
    print(f"Alice's private key: {alice.private_key}")
    print(f"Bob's private key: {bob.private_key}\n")
    
    print("Public Keys (can be shared):")
    print(f"Alice's public key: {alice.public_key}")
    print(f"Bob's public key: {bob.public_key}\n")
    
    # Generate shared secrets
    alice_shared_secret = alice.generate_shared_secret(bob.public_key)
    bob_shared_secret = bob.generate_shared_secret(alice.public_key)
    
    print("Shared Secrets (should match):")
    print(f"Alice's shared secret: {alice_shared_secret}")
    print(f"Bob's shared secret: {bob_shared_secret}")
    
    # Verify that both parties generated the same shared secret
    if alice_shared_secret == bob_shared_secret:
        print("\nSuccess! Both parties generated the same shared secret.")
    else:
        print("\nError: Shared secrets do not match.")

if __name__ == "__main__":
    main()