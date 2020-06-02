#region License
// Copyright (c) 2020 Davide Gironi
//
// Please refer to LICENSE file for licensing information.
#endregion

using System;
using System.Security.Cryptography;
using System.Text;

namespace DG.DoctcoD.Helpers
{
    public class PasswordHelper
    {
        /// <summary>
        /// Entropy bytes
        /// </summary>
        private static byte[] _salt = new byte[] { 0xA2, 0x56, 0xF3, 0x78, 0xB8, 0x21, 0x82, 0xAF, 0xC2, 0x06, 0x6A, 0x31 };

        /// <summary>
        /// Encrypt a password
        /// </summary>
        /// <param name="password"></param>
        public static string EncryptPassword(string password)
        {
            if (String.IsNullOrEmpty(password))
                password = "";

            HMACMD5 hmacMD5 = new HMACMD5(_salt);
            return Convert.ToBase64String(hmacMD5.ComputeHash(Encoding.Unicode.GetBytes(password)));
        }

        /// <summary>
        /// Check if a prompt password is valid
        /// </summary>
        /// <param name="promptpassword"></param>
        /// <param name="encryptedpassword"></param>
        /// <returns></returns>
        public static bool CheckPassword(string promptpassword, string encryptedpassword)
        {
            return (EncryptPassword(promptpassword) == encryptedpassword);
        }
    }
}
