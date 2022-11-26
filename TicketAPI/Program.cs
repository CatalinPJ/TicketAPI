using TicketAPI.Extensions;
using TicketAPI.Persistence.Database;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCustomServices();
var customOriginName = "_myAllowSpecificOrigins";
builder.Services.AddCustomCors(customOriginName);

builder.Services.AddDbContext<TicketContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("TicketsDB")));

var secretKey = builder.Configuration.GetSection("Authorization").GetValue("Secret", string.Empty);
builder.Services.AddCustomAuthorization(secretKey);
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureExceptionHandler();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors(customOriginName);

app.Run();
