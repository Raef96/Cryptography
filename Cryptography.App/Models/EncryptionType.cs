namespace Cryptography.App.Models
{
    internal class EncryptionType
    {
        public const string AsymetricEncryption = "Asymetric Encryption";
        public const string SymetricEncryption = "Symetric Encryption";

        public enum EncryptionOption
        {
            AsymetricEncryption,
            SymetricEncription,
            None
        }
        
        public static EncryptionOption FromLabelToOption(string label)
        {
            switch (label)
            {
                case AsymetricEncryption:
                    return EncryptionOption.AsymetricEncryption;
                case SymetricEncryption:
                    return EncryptionOption.SymetricEncription;
                default:
                    return EncryptionOption.None;
            }
        }
    }
}
