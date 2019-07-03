using System.Threading.Tasks;
using Octovisor.Client;

namespace Energize.Web.Services
{
    public interface ITransmissionService
    {
        OctoClient Client { get; }

        Task<T> TransmitToEnergizeAsync<T>(string identifier);
    }
}
