using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;

namespace WebTest.Controllers
{
    public class KeyVaultService
    {
        private readonly SecretClient _secretClient;

        public KeyVaultService(IConfiguration configuration)
        {
            // 取得 Key Vault URI 和 Managed Identity 的設定
            var keyVaultUri = new Uri(configuration["KeyVaultUri"]);
            var credential = new DefaultAzureCredential();

            // 建立 SecretClient 實例
            _secretClient = new SecretClient(keyVaultUri, credential);
        }

        public async Task<string> GetSecretAsync(string secretName)
        {
            try
            {
                // 使用 SecretClient 讀取 Key Vault 中的機密
                KeyVaultSecret secret = await _secretClient.GetSecretAsync(secretName);
                return secret.Value;
            }
            catch (Exception ex)
            {
                // 處理錯誤
                Console.WriteLine($"Error accessing Key Vault: {ex.Message}");
                return null;
            }
        }
    }
}
