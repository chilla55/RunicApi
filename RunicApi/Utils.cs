﻿namespace RunicApi
{
    public class Utils
    {
        public static string generateKey()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string ret = new string(Enumerable.Repeat(chars, 16)
                             .Select(s => s[random.Next(s.Length)]).ToArray());
            if (!RunicApi.Data.Instance.KeyLanguage.ContainsKey(ret))
                return ret;
            return generateKey();
        }
    }
}
