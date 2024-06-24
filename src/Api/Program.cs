using Andreani.Arq.AMQStreams.Extensions;
using Andreani.Arq.Observability.Extensions;
using Andreani.Arq.WebHost.Extension;
using Andreani.Scheme.Onboarding;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using workerOnBording.Infrastructure.Services;
using workerOnBording.Application.Boopstrap;
using workerOnBording.Infrastructure.Boopstrap;
using static workerOnBording.Services.WorkerService;

var builder = WebApplication.CreateBuilder(args);

builder.ConfigureAndreaniWebHost(args);
builder.Services.ConfigureAndreaniWorkerServices();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddKafka(builder.Configuration)
			.CreateOrUpdateTopic(6, "Onboarding-PedidoAsignado-Mrey")
			.ToConsumer<EventSubscriber, Pedido>("Onboarding-PedidoCreado-Mrey")
			.ToProducer<Pedido>("Onboarding-PedidoAsignado-Mrey")
			.Build();
builder.Host.AddObservability();
builder.Services.AddScoped<IScopedService, ScopedService>();
builder.Services.AddHostedService<WorkerServices>();

var app = builder.Build();

app.UseObservability();
app.ConfigureAndreaniWorker();

app.Run();