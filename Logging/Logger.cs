using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace ddd_exercise
{
    internal static class Logger
    {
        private static bool _initialized;
        private static string _path;
        private const string BaseFolder = ".logs";

        private static readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy()
            }
        };

        internal static void Init(string scenario)
        {
            if (_initialized) throw new InvalidOperationException("Logger already initialized");

            if (!Directory.Exists(BaseFolder))
            {
                Directory.CreateDirectory(BaseFolder);
            }
            _path = $"{BaseFolder}/{scenario}.log";
            if (File.Exists(_path))
            {
                File.Delete(_path);
            }

            _initialized = true;
        }

        internal static void Log(LogMessage message)
        {
            if (!_initialized) throw new InvalidOperationException("Logger has to be initialized first");
            File.AppendAllLines(_path, new[] { JsonConvert.SerializeObject(message, _serializerSettings) });
        }
    }
}
