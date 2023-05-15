//Takes traffic light status data from the DataHandler class and sends it to the WPF Application client
using exercise_b.DataWorker;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO.Pipes;

namespace exercise_b.Server
{
    internal class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                await using var pipeServer = new NamedPipeServerStream("testpipe", PipeDirection.Out);

                // Wait for a client to connect
                await pipeServer.WaitForConnectionAsync();

                try
                {
                    // Read user input and send that to the client process.
                    await using var sw = new StreamWriter(pipeServer);
                    sw.AutoFlush = true;
                    sw.WriteLine(DataHandler.GetString());
                }
                // Catch the IOException that is raised if the pipe is broken
                // or disconnected.
                catch (IOException e)
                {
                    _logger.LogInformation("ERROR: {0}", e.Message);
                }

                Thread.Sleep(500);
            }
        }
    }
}
