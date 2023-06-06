namespace ChatGPTApi.Models
{
    public class ApiKeyModel
    {
        public string? LocationPath { get; set; }

        public string GetApiKey()
        {
            if (!string.IsNullOrEmpty(LocationPath))
            {
                if (File.Exists(LocationPath))
                {
                    string encryptedApiKey = File.ReadAllText(LocationPath);
                    return DecryptedApiKey(encryptedApiKey);
                }

            }

            return string.Empty;
        }

        private static string DecryptedApiKey(string encryptedApiKey)
        {
            //TODO: Add decryption and actually encrypt the provided key.
            //Could be something along the lines of this: https://www.c-sharpcorner.com/article/best-algorithm-for-encrypting-and-decrypting-a-string-in-c-sharp/
            string decryptedApiKey = encryptedApiKey;
            return decryptedApiKey;
        }
    }
}
