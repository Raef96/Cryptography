using Newtonsoft.Json;

namespace Cryptography.Core.Models
{
    internal class SymmetricKeyAES
    {
        public string? Key { get; set; }
        public string? IV { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }
    }
}
