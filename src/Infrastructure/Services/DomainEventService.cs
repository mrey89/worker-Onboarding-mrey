﻿using workerOnBording.Application.Common.Interfaces;
using workerOnBording.Domain.Common;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace workerOnBording.Infrastructure.Services;

public class DomainEventService : IDomainEventService
{
    private readonly ILogger<DomainEventService> _logger;

    public DomainEventService(ILogger<DomainEventService> logger)
    {
        _logger = logger;
    }

    public Task Publish(DomainEvent domainEvent)
    {
        // publish
        throw new NotImplementedException();
    }

}
