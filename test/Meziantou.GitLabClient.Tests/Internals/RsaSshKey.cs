using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace Meziantou.GitLab.Tests
{
    public class RsaSshKey
    {
        private const int PrefixSize = 4;
        private const int PaddedPrefixSize = PrefixSize + 1;
        private const string KeyType = "ssh-rsa";

        public string PublicKey { get; }
        public string PrivateKey { get; }

        public RsaSshKey(string publicKey, string privateKey)
        {
            PublicKey = publicKey ?? throw new ArgumentNullException(nameof(publicKey));
            PrivateKey = privateKey ?? throw new ArgumentNullException(nameof(privateKey));
        }

        public static RsaSshKey GenerateQuickest()
        {
            using var rsa = RSA.Create();
            var size = rsa.LegalKeySizes.Min();
            rsa.KeySize = size.MinSize;

            return Generate(rsa);
        }

        public static RsaSshKey Generate(int keyLength)
        {
            using var rsa = RSA.Create(keyLength);
            return Generate(rsa);
        }

        public static RsaSshKey Generate(RSA cryptoServiceProvider)
        {
            var keyParameters = cryptoServiceProvider.ExportParameters(includePrivateParameters: true);

            var publicBuffer = new byte[3 + KeyType.Length + PaddedPrefixSize + keyParameters.Exponent.Length + PaddedPrefixSize + keyParameters.Modulus.Length + 1];
            using (var writer = new BinaryWriter(new MemoryStream(publicBuffer)))
            {
                writer.Write(new byte[] { 0x00, 0x00, 0x00 });
                writer.Write(KeyType);
                WritePrefixed(writer, keyParameters.Exponent, addLeadingNull: true);
                WritePrefixed(writer, keyParameters.Modulus, addLeadingNull: true);
            }

            var privateBuffer = new byte[PaddedPrefixSize + keyParameters.D.Length + PaddedPrefixSize + keyParameters.P.Length + PaddedPrefixSize + keyParameters.Q.Length + PaddedPrefixSize + keyParameters.InverseQ.Length];
            using (var writer = new BinaryWriter(new MemoryStream(privateBuffer)))
            {
                WritePrefixed(writer, keyParameters.D, addLeadingNull: true);
                WritePrefixed(writer, keyParameters.P, addLeadingNull: true);
                WritePrefixed(writer, keyParameters.Q, addLeadingNull: true);
                WritePrefixed(writer, keyParameters.InverseQ, addLeadingNull: true);
            }

            var publicBlob = KeyType + " " + Convert.ToBase64String(publicBuffer);
            var privateBlob = Convert.ToBase64String(privateBuffer);
            return new RsaSshKey(publicBlob, privateBlob);
        }

        private static void WritePrefixed(BinaryWriter writer, byte[] bytes, bool addLeadingNull = false)
        {
            var length = bytes.Length;
            if (addLeadingNull)
            {
                length++;
            }

            writer.Write(BitConverter.GetBytes(length).Reverse().ToArray());
            if (addLeadingNull)
            {
                writer.Write((byte)0x00);
            }

            writer.Write(bytes);
        }
    }
}
