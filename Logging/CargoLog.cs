using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ddd_exercise
{
    internal class CargoLog
    {
        [JsonProperty("cargo_id")]
        public int CargoId { get; set; }
        public string Destination { get; set; }
        public string Origin { get; set; }
    }
}
