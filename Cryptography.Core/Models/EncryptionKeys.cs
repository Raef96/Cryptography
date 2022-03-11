using Newtonsoft.Json;

namespace Cryptography.Core.Models
{
    internal class EncryptionKeys
    {
        public EncryptionKeys(string keys)
        {
            var symmetricKey = JsonConvert.DeserializeObject<SymmetricKeyAES>(keys);
            if (symmetricKey?.Key is not null || symmetricKey?.IV is not null)
            {
                SymmetricKey = symmetricKey;
            }

            var asymmetricKey = JsonConvert.DeserializeObject<AsymmetricKeyRSA>(keys);
            if (asymmetricKey?.PublicKey is not null && asymmetricKey?.PrivateKey is not null)
            {
                AsymmetricKey = asymmetricKey;
            }
        }
        public SymmetricKeyAES? SymmetricKey { get; init; } = default;
        public AsymmetricKeyRSA? AsymmetricKey { get; init; } = default;
    }
}
