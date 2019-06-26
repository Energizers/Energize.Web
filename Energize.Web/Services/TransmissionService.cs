using System;
using Octovisor.Client;
using Octovisor.Messages;

namespace Energize.Web.Services
{
    public class TransmissionService
    {
        public static TransmissionService Instance { get; } = Initialize();

        private static TransmissionService Initialize()
        {
            TransmissionService service = new TransmissionService();
            service.Client = new OctoClient(Config.Instance.Octovisor);
            service.Client.Log += OnLog;

            return service;
        }

        private static void OnLog(LogMessage log)
        {
            if (log.Severity == LogSeverity.Info)
                Console.WriteLine(log.Content);
        }

        public OctoClient Client { get; private set; }
    }
}
