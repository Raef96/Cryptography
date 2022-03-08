using Newtonsoft.Json;

namespace Cryptography.Core.Models
{
    internal class AsymmetricKeyRSA
    {
        public string? PublicKey { get; set; }
        public string? PrivateKey { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}