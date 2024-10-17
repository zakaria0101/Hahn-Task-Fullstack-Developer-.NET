using Back_End.Data;
using Microsoft.EntityFrameworkCore;
using Back_End.Interfaces;
using Back_End.Repositories;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

// Define a CORS policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
builder.Services.AddDbContext<ApplicationDBContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ITicketRepository, TicketRepository>();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors("AllowAllOrigins");

app.UseAuthorization();

app.MapControllers();

app.Run();