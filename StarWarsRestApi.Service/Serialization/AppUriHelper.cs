using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Hosting.Server.Features;

namespace StarWarsRestApi.Service.Serialization
{
    public static class AppUriHelper
    {
        public static Uri AppUri { get; set; } = new Uri("http://localhost");

        public static bool IsInitialized { get; set; }

        /// <summary>
        /// Sets the <see cref="AppUri"/> for future calls.
        /// </summary>
        /// <param name="server">The server object.</param>
        public static void Initialize(IServer server)
        {
            if (!IsInitialized)
            {
                var address = server.Features.Get<IServerAddressesFeature>()?.Addresses.FirstOrDefault(addr => addr.StartsWith("https://")) ?? "http://localhost";
                AppUri = new Uri(address);
                IsInitialized = true;
            }
        }
    }
}
