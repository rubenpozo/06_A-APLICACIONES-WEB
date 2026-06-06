using Microsoft.EntityFrameworkCore;
using EncuestasApp.Models;

var builder = WebApplication.CreateBuilder(args);
// Registrar el DbContext en el contenedor de servicios
builder.Services.AddDbContext<EncuestasDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("EncuestasDB")));
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
