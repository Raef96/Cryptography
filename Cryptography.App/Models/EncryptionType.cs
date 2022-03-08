namespace Cryptography.App.Models
{
    internal class EncryptionType
    {
        public const string AsymmetricEncryption = "Asymmetric Encryption";
        public const string SymmetricEncryption = "Symmetric Encryption";

        public enum EncryptionOption
        {
            AsymmetricEncryption,
            SymmetricEncription,
            None
        }
        
        public static EncryptionOption FromLabelToOption(string label)
        {
            switch (label)
            {
                case AsymmetricEncryption:
                    return EncryptionOption.AsymmetricEncryption;
                case SymmetricEncryption:
                    return EncryptionOption.SymmetricEncription;
                default:
                    return EncryptionOption.None;
            }
        }
    }
}
