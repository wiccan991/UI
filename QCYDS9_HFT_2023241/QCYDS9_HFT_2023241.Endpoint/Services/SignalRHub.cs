﻿using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.SignalR;

namespace QCYDS9_HFT_2023241.Endpoint.Services
{
    public class SignalRHub: Hub
    {
        public override Task OnConnectedAsync()
        {
            Clients.Caller.SendAsync("Connected", Context.ConnectionId);
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            Clients.Caller.SendAsync("Disconnected", Context.ConnectionId);
            return base.OnDisconnectedAsync(exception);
        }
    }
}
