using BisleriumCafe.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BisleriumCafe.Services
{
    public class Utility
    {
        private const char _segmentDelimiter = ':';

        public static String GetUserDirectoryPath()
        {
            return Path.Combine(Constants.DATADIRECTORYPATH, "operators.json");
        }
        public static String GetCoffeeDirectoryPath()
        {
            return Path.Combine(Constants.DATADIRECTORYPATH, "coffee.json");
        }
        public static String GetAddinsDirectoryPath()
        {
            return Path.Combine(Constants.DATADIRECTORYPATH, "addins.json");
        }
        public static String GetMemberDirectoryPath()
        {
            return Path.Combine(Constants.DATADIRECTORYPATH, "members.json");
        }
        public static string PasswordHash(string input)
        {
            var saltSize = 16;
            var iterations = 100_000;
            var keySize = 32;
            var algorithm = HashAlgorithmName.SHA256;
            var salt = RandomNumberGenerator.GetBytes(saltSize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(input, salt, iterations, algorithm, keySize);

            var result = string.Join(
                _segmentDelimiter,
                Convert.ToHexString(hash),
                Convert.ToHexString(salt),
                iterations,
                algorithm
            );

            return result;
        }

        public static bool CheckHashPassword(string inputPassword, string userHashPassword)
        {
            var segments = userHashPassword.Split(_segmentDelimiter);
            var hash = Convert.FromHexString(segments[0]);
            var salt = Convert.FromHexString(segments[1]);
            var iterations = int.Parse(segments[2]);
            var algorithm = new HashAlgorithmName(segments[3]);
            var inputHash = Rfc2898DeriveBytes.Pbkdf2(
                inputPassword,
                salt,
                iterations,
                algorithm,
                hash.Length
            );

            return CryptographicOperations.FixedTimeEquals(inputHash, hash);
        }
    }
}
