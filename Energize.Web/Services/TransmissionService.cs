using System;
using System.Threading.Tasks;
using Octovisor.Client;
using Octovisor.Messages;

namespace Energize.Web.Services
{
    public class TransmissionService : ITransmissionService
    {
        public TransmissionService()
        {
            this.Client = new OctoClient(Config.Instance.Octovisor);
            this.Client.Log += OnLog;
        }

        public OctoClient Client { get; }

        private static void OnLog(LogMessage log)
        {
            if (log.Severity > 0) // anything but debug logs
                Console.WriteLine(log.Content);
        }

        public async Task<T> TransmitToEnergizeAsync<T>(string identifier)
        {
            T data = default;
            try
            {
                OctoClient client = this.Client;
                if (!client.IsConnected)
                    await client.ConnectAsync();

                if (client.TryGetProcess("Energize", out RemoteProcess proc))
                    data = await proc.TransmitAsync<T>(identifier);

                return data == default ? Activator.CreateInstance<T>() : data;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return data == default ? Activator.CreateInstance<T>() : default;
            }
        }

        public async Task<bool> TransmitToEnergizeAsync(string identifier)
        {
            try
            {
                OctoClient client = this.Client;
                if (!client.IsConnected)
                    await client.ConnectAsync();

                if (client.TryGetProcess("Energize", out RemoteProcess proc))
                {
                    await proc.TransmitAsync(identifier);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }

        public async Task<bool> TransmitToEnergizeAsync<T>(string identifier, T value) where T : class
        {
            try
            {
                OctoClient client = this.Client;
                if (!client.IsConnected)
                    await client.ConnectAsync();

                if (client.TryGetProcess("Energize", out RemoteProcess proc))
                {
                    await proc.TransmitObjectAsync(identifier, value);
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;
            }
        }
    }
}
