using BusinessLogic.Interfaces;
using BusinessLogic.Services;
using DataLayer.Extensions;
using DataLayer.Interfaces;
using DataLayer.Repositories;
using FluentValidation.AspNetCore;
var builder = WebApplication.CreateBuilder(args);

string dbConnection = builder.Configuration.GetConnectionString("DBConnection");
builder.Services.AddEventAppContext(dbConnection);
builder.Services.AddRepositories();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<ILocationService, LocationService>();
builder.Services.AddScoped<ITicketService, TicketService>();
builder.Services.AddScoped<IUserEventService, UserEventService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddControllers().AddFluentValidation(c => c.RegisterValidatorsFromAssemblyContaining<Program>());



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
