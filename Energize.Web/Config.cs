using System.IO;
using Octovisor.Client;
using YamlDotNet.Serialization;

namespace Energize.Web
{
    public struct DiscordConfig
    {
        public string ClientID;
        public string ClientSecret;
    }

    public class Config
    {
        public DiscordConfig Discord;
        public OctoConfig Octovisor;

        public static Config Instance { get; } = Initialize();

        private static Config Initialize()
        {
            if (!File.Exists("config.yaml"))
                throw new FileNotFoundException();

            string yaml = File.ReadAllText("config.yaml");
            Deserializer deserializer = new Deserializer();
            return deserializer.Deserialize<Config>(yaml);
        }
    }
}
