using workerOnBording.Domain.Common;
using System.Threading.Tasks;

namespace workerOnBording.Application.Common.Interfaces;

public interface IDomainEventService
{
    Task Publish(DomainEvent domainEvent);
}
