using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PlazaDbContext>(opciones =>
    opciones.UseNpgsql(builder.Configuration.GetConnectionString("Plaza")));
builder.Services.AddScoped<ICatalogo, CatalogoEf>();
builder.Services.AddSingleton<IPedidos, PedidosEnMemoria>();

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();

app.Run();
// Host=plaza-pg-iue603.postgres.database.azure.com;Port=5432;Database=plaza_campesina;Username=plazaadmin;Password=Qwert12345;SSL Mode=Require
// dotnet ef database update --connection "Host=plaza-pg-iue603.postgres.database.azure.com;Port=5432;Database=plaza_campesina;Username=plazaadmin;Password=Qwert12345;SSL Mode=Require"