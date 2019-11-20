using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ddd_exercise
{
    internal class LogMessage
    {
        public string Event { get; set; }
        public int Time { get; set; }
        [JsonProperty("transport_id")]
        public int TransportId { get; set; }
        public string Kind { get; set; }
        public string Location { get; set; }
        public string Destination { get; set; }
        public CargoLog[] Cargo { get; set; }
    }
}
