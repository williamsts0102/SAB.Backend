using Microsoft.AspNetCore.SignalR;
using SAB.Backend.SignalR.Clases;

namespace SAB.Backend.SignalR
{
    public class AlertHub : Hub
    {
        public async Task SendAlert(Alerta alerta)
        {
            await Clients.All.SendAsync("ReceiveAlert", alerta);
        }
    }
}
