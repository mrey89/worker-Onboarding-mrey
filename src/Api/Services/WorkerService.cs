using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace workerOnBording.Services
{
    public class WorkerService
    {
        public class WorkerServices : BackgroundService
        {
            private readonly IServiceScopeFactory _scopeFactory;

            public WorkerServices(IServiceScopeFactory scopeFactory)
            {
                _scopeFactory = scopeFactory ?? throw new ArgumentNullException(nameof(scopeFactory));
            }
            protected override async Task ExecuteAsync(CancellationToken stoppingToken)
            {

                using (var scope = _scopeFactory.CreateScope())
                {
                    var scopedService = scope.ServiceProvider.GetRequiredService<IScopedService>();
                }

            }
        }

        public interface IScopedService
        {
        }

        public class ScopedService : IScopedService
        {
            private readonly ILogger<ScopedService> _logger;
            private readonly ISender _mediator;

            public ScopedService(ILogger<ScopedService> logger, ISender mediator)
            {
                _logger = logger;
                _mediator = mediator;
            }


        }
    }
}
