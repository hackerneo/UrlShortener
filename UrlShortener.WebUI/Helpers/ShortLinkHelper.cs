using System;
using System.Text;

namespace UrlShortener.WebUI.Helpers
{
    public static class ShortLinkHelper
    {
        public static Random Random = new Random();

        public static String GuidToShortLinkConverter(Guid guid)
        {
            var result = new StringBuilder();
            var alphabet = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var guidBytes = guid.ToByteArray();

            foreach (var b in guidBytes)
            {
                if (b > 0)
                    result.Append(alphabet[b]);
            }

            return result.ToString();
        }

        public static Guid ShortLinkToGuidConverter(String shortLink)
        {
            var guidBytes = new Byte[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var alphabet = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            for (var i = 0; i < shortLink.Length; i++)
            {
                guidBytes[i] = (Byte)alphabet.IndexOf(shortLink[i]);
            }

            return new Guid(guidBytes);
        }

        public static Guid NewShortLink(Byte shortLinkLength = 8)
        {
            var guidBytes = new Byte[16] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            var alphabet = " abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            for (var i = 0; i < shortLinkLength; i++)
            {
                guidBytes[i] = (Byte)ShortLinkHelper.Random.Next(1, alphabet.Length - 1);
            }

            return new Guid(guidBytes);
        }
    }
}