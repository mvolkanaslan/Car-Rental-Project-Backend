using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Hashing
{
    public class HashingHelper
    {
        //girilen password un hash kodunu oluşturuyor ilave olarak password e salt ekliyor 
        public static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;//Her kullanıcı register için yeni bir key oluşur ve hash de kullanılır.
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));//Burada Pass byte array olarak verilmeli
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            //sorgulamda hmac için kullanıcıya ait salt değeri de eklenir. 
            //sonra yeniden bir hash oluşturulup databasedeki ile byte to byte karşılaştırılır.
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        }
    }
}
