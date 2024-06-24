using Andreani.Arq.AMQStreams.Class;
using Andreani.Arq.AMQStreams.Interface;
using Andreani.Scheme.Onboarding;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace workerOnBording.Infrastructure.Services
{
    public class EventSubscriber(IPublisher publisher, ILogger<EventSubscriber> logger) : ISubscriber
    {
        public async Task Consume(Pedido @event, ConsumerMetadata metadata)
        {
            logger.LogInformation($"Content event Id: {@event.id} - Estado: {@event.estadoDelPedido} - {metadata.Key}");

            Random random = new Random();
            int Numeracion = random.Next();

            @event.numeroDePedido = Numeracion;
            @event.estadoDelPedido = "ASIGNADO";

            await publisher.To(@event, @event.id);

            logger.LogInformation("Publicacion Evento Asignado con id: ", @event.id);

        }
    }
}
