using System.Net.Sockets;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using Roulette.Aids;
using System;
using Roulette.Models;

public class JsonTcpServer
{
    private TcpListener _listener;
    public event EventHandler<int>? OnWinningNumberCame;
    public event EventHandler<int>? On10SecondsPassed;
    public JsonTcpServer(int port)
    {
        _listener = new TcpListener(IPAddress.Any, port);
    }

    public static async Task<JsonTcpServer> CreateAsync(int port, RouletteModel model)
    {
        JsonTcpServer server = new JsonTcpServer(port);
        server.OnWinningNumberCame += model.Server_OnWinningNumberCame;
        server.On10SecondsPassed += model.Server_On10SecondsPassed;
        await server.StartAsync();
        return server;
    }

    public async Task StartAsync()
    {
        _listener.Start();
        while (true)
        {
            try
            {
                using (var _client = await _listener.AcceptTcpClientAsync())
                {
                    await HandleClientAsync(_client);
                }
            }
            catch
            {
            }
        }
    }

    public async Task HandleClientAsync(TcpClient client)
    {
        using (var stream = client.GetStream())
        {
            using (StreamReader sr = new StreamReader(stream))
            {
                var message = await sr.ReadToEndAsync();
                JsonRequestWrapper? req = System.Text.Json.JsonSerializer.Deserialize<JsonRequestWrapper>(message);
                if (req != null)
                {
                    if (req.Data != null && req.Qualifier != null)
                    {
                        if (req.Data.WinningNumber <= 36 && req.Data.WinningNumber >= 0 && req.Qualifier == "showWinningNumber")
                        {
                            var winningNumber = req.Data.WinningNumber;

                            OnWinningNumberCame?.Invoke(this, winningNumber);
                            await Task.Delay(10000);
                            On10SecondsPassed?.Invoke(this, winningNumber);
                        }
                    }
                }
            }
        }
    }
}
