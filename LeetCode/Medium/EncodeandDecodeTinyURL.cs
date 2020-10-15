using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace LeetCode
{
    class EncodeandDecodeTinyURL : BaseClass
    {
        public override void Run()
        {
            string shortUrl = encode("https://leetcode.com/problems/design-tinyurl");
            var output = decode(shortUrl);
        }

        Dictionary<string, string> map = new Dictionary<string, string>();
        const string basetinyurl = "http://tinyurl.com/";
        //const string https = "https://";
        public string encode(string longUrl)
        {
            //if (longUrl.StartsWith(https))
            //    longUrl = longUrl.Substring(https.Length );
            var shorturl = CreateaHash(longUrl);
            
            map.Add(shorturl, longUrl);
            return basetinyurl+shorturl;
        }

        private string CreateaHash(string longUrl)
        {
            string encodedTxt = Convert.ToBase64String(GetHash(longUrl));

            return encodedTxt;
        }
        public static byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }
        // Decodes a shortened URL to its original URL.
        public string decode(string shortUrl)
        {
            if (shortUrl.StartsWith(basetinyurl))
                shortUrl = shortUrl.Substring(basetinyurl.Length);
            map.TryGetValue(shortUrl, out string longUrl);
            return longUrl;
        }
    }
}
