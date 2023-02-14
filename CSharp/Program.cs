using System;
using System.IO;
using System.Security.Cryptography;

namespace CSharp
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var key = File.ReadAllBytes(@"..\..\..\data\public.pem");
            var rsa = new RSACryptoServiceProvider();
            rsa.ImportCspBlob(key);
            var signature = File.ReadAllBytes(@"..\..\..\data\test.txt.sign");
            var data = File.ReadAllBytes(@"..\..\..\data\test.txt");
            var sha256 = new SHA256Managed();
            var hash = sha256.ComputeHash(data);
            var result = rsa.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA256"), signature);
            Console.WriteLine(result);
        }
    }
}