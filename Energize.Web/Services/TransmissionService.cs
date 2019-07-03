using System;
using System.Threading.Tasks;
using Octovisor.Client;
using Octovisor.Client.Exceptions;
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
            if (log.Severity == LogSeverity.Info)
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

                return data == null ? Activator.CreateInstance<T>() : data;
            }
            catch (TimeOutException)
            {
                return data == null ? Activator.CreateInstance<T>() : default;
            }
        }
    }
}
