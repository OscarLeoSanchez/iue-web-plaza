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