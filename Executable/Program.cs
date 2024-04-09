var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDemoServices(builder.Configuration);

builder
    .Build()
    .UseDemoMiddleware()
    .Run();