using System.Threading.RateLimiting;
using StackExchange.Redis;
using WeatherApi.Services;
using Microsoft.AspNetCore.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// Framework essentials
builder.Services.AddControllers();
builder.Services.AddOpenApi();

// Application services
builder.Services.AddHttpClient<WeatherService>();

// Infrastructure
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var configuration = new ConfigurationOptions
    {
        EndPoints = { { "redis-10926.c295.ap-southeast-1-1.ec2.redns.redis-cloud.com", 10926 } },
        User = "default",
        Password = "KulCAxwRt3RHj313Z7QrqcJT7JTQkVp2",
        AbortOnConnectFail = false,
        Ssl = true,
    };

    return ConnectionMultiplexer.Connect("localhost");
});

builder.Services.AddSingleton<IDatabase>(sp =>
{
    var muxer = sp.GetRequiredService<IConnectionMultiplexer>();
    return muxer.GetDatabase();
});

builder.Services.AddRateLimiter(options => {
    options.AddFixedWindowLimiter("fixed", opt =>
    {
        opt.PermitLimit = 20; // Allow 5 requests
        opt.Window = TimeSpan.FromSeconds(10); // Per 10 seconds
        opt.QueueLimit = 0; // No queued requests
        opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseRateLimiter();
app.MapControllers().RequireRateLimiting("fixed");
app.Run();
