using System;
using System.Numerics;
using System.Security.Cryptography;

namespace CryptographyExamples
{
    public class DiffieHellman
    {
        private readonly BigInteger _prime;
        private readonly BigInteger _generator;
        private readonly BigInteger _privateKey;
        public BigInteger PublicKey { get; private set; }

        public DiffieHellman(BigInteger? prime = null, BigInteger? generator = null)
        {
            _prime = prime ?? new BigInteger(17);  
            _generator = generator ?? 3;  
            _privateKey = GeneratePrivateKey();
            PublicKey = BigInteger.ModPow(_generator, _privateKey, _prime);
        }

        private BigInteger GeneratePrivateKey()
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] bytes = new byte[4]; 
                rng.GetBytes(bytes);
                return new BigInteger(bytes) % (_prime - 2) + 2;
            }
        }

        public BigInteger GetSecret(BigInteger otherPublicKey)
        {
            return BigInteger.ModPow(otherPublicKey, _privateKey, _prime);
        }

        public static void Main()
        {
            var ibrahim = new DiffieHellman();
            var zaki = new DiffieHellman(ibrahim._prime, ibrahim._generator);

            Console.WriteLine("DiffiHellman Exchange \n");
            Console.WriteLine($"prime: {ibrahim._prime}");
            Console.WriteLine($"generator: {ibrahim._generator}\n");

            Console.WriteLine("Public Keys:");
            Console.WriteLine($"ibrahim's public key: {ibrahim.PublicKey}");
            Console.WriteLine($"zaki's public key: {zaki.PublicKey}\n");

            // Generate shared secrets
            var ibrahimSecretKey = ibrahim.GetSecret(zaki.PublicKey);
            var zakiSecretKey = zaki.GetSecret(ibrahim.PublicKey);

            Console.WriteLine("Shared Secrets:");
            Console.WriteLine($"ibrahim's secret: {ibrahimSecretKey}");
            Console.WriteLine($"zaki's secret: {zakiSecretKey}\n");

            Console.WriteLine(ibrahimSecretKey == zakiSecretKey 
                ? "Success! Both parties generated the same shared secret."
                : "Error: Shared secrets do not match.");
        }
    }
}