using Clients.Controllers;
using Clients.Data;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ClientContext>(options =>
{
    options.UseMySql(connectionString: builder.Configuration.GetConnectionString("ClientContext"),
        new MariaDbServerVersion(ServerVersion.Create(new Version(10, 9, 1), ServerType.MariaDb)));
});

builder.Services.AddScoped<IClientManager, ClientManager>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Client}/{action=Index}");

app.Run();
