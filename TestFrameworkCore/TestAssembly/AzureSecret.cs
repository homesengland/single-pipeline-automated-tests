using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using He.TestFramework.TestBase.Web;

namespace TestFrameworkWeb.TestAssembly
{ 
        public static class AzureSecret
        {
        public static async Task GetAzureSecret(string Secret)
        {
            string secretName = AppReader.GetConfigValue(Secret);
            var keyVaultName = AppReader.GetConfigValue("KeyVaultName");
            var kvUri = AppReader.GetConfigValue("KeyVaultURI");

            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

            Console.WriteLine($"Retrieving your secret from {keyVaultName}.");
            var secret = await client.GetSecretAsync(secretName);

            //StaticObjectRepo.UserName = secret.Value.Value;
        }


        public static async Task GetCredentialsFromAzureSecrets(string secretUName, string secretPass)
        {
            var keyVaultName = AppReader.GetConfigValue("KeyVaultName");
            var kvUri = AppReader.GetConfigValue("KeyVaultURI");

            var client = new SecretClient(new Uri(kvUri), new DefaultAzureCredential());

            Console.WriteLine($"Retrieving your secret from {keyVaultName}.");
            var secret = await client.GetSecretAsync(secretUName);
            StaticObjectRepo.UserName = secret.Value.Value;

            secret = await client.GetSecretAsync(secretPass);
            StaticObjectRepo.Password = secret.Value.Value;
        }
    }
}
 