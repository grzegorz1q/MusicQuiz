using MassTransit;
using Microsoft.EntityFrameworkCore;
using MusicQuiz.Services.Scoreboard.Application.CQRS.Queries;
using MusicQuiz.Services.Scoreboard.Application.Integration.Consumers;
using MusicQuiz.Services.Scoreboard.Domain.Interfaces;
using MusicQuiz.Services.Scoreboard.Infrastructure.Persistence;
using MusicQuiz.Services.Scoreboard.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetScoreboardQueryHandler).Assembly));

builder.Services.AddDbContext<ScoreboardDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<AwardPointsConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.Host("localhost", "/", h =>
        {
            h.Username("guest");
            h.Password("guest");
        });
        cfg.ReceiveEndpoint("award-points", e =>
        {
            e.ConfigureConsumer<AwardPointsConsumer>(context);
        });
    });
});

builder.Services.AddScoped<IPlayerScoreRepository, PlayerScoreRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
