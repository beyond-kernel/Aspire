var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedisContainer("cache");

var rabbitmq = builder.AddRabbitMQContainer("rabbitmq");

var apiservice = builder.AddProject<Projects.Aspire_ApiService>("apiservice");

builder.AddProject<Projects.Aspire_Web>("webfrontend")
      .WithReference(cache)
      .WithReference(rabbitmq)
    .WithReference(apiservice);

builder.Build().Run();
