using System;
using System.Security.Cryptography;
using System.Text;

namespace XUnitStudyProject.Services
{
    public class PasswordHasher
    {
        /// <summary>
        /// Метод принимает в себя пароль, после чего производит его хеширование в MD5
        /// </summary>
        /// <param name="password"></param>
        public byte[] Md5HashPassword(string password)
        {
            byte[] bytes = Encoding.Default.GetBytes(password);
            MD5 md5 = new MD5CryptoServiceProvider();
            md5.ComputeHash(bytes);
            return md5.Hash;
        }
        /// <summary>
        /// Метод принимает в себя MD5 hash (массив байт)
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns>Возвращается значение хэша в hexCode</returns>
        public string ToHex(byte[] bytes)
        {
            var result = BitConverter.ToString(bytes)
                .Replace("-", "").ToLower();
            return result;
        }
    }
}